using NLog;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InfoApp
{
    public partial class AddUserForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private int UserId { get; set; }
        public bool DataSubmitted { get; set; } = false;


        public class EnumItem
        {
            public Enum EnumValue { get; set; }
            public int IntValue { get; set; }
            public string DisplayName { get; set; }

            public EnumItem(Enum value)
            {
                EnumValue = value;
                IntValue = (int)(object)value;
                DisplayName = value.GetDescription();
            }
        }

        public int GetSelectedStatusInt()
        {
            if (cbAccessLevel.SelectedItem is EnumItem selectedItem)
            {
                return selectedItem.IntValue;
            }
            return -1;
        }

        private void InitializeComboBox()
        {
            var items = Enum.GetValues(typeof(UserAccessLevel))
                           .Cast<UserAccessLevel>()
                           .Select(x => new EnumItem(x))
                           .ToList();

            cbAccessLevel.DisplayMember = "DisplayName";
            cbAccessLevel.ValueMember = "IntValue";
            cbAccessLevel.DataSource = items;
        }

        public AddUserForm()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        public AddUserForm(DataRow data)
        {
            InitializeComponent();
            InitializeComboBox();

            this.Text = "Редактирование пользователя";
            btnAdd.Text = "Сохранить";

            UserId = (int)data["id"];
            txtLogin.Text = data["login"].ToString();
            txtPassword.Text = string.Empty;
            cbAccessLevel.SelectedValue = (int)data["accessLevel"];
        }


        private void AddClientForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserId != 0)
                {
                    DialogResult result = MessageBox.Show("Сохранить изменения?", "Подтверждение формы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if (txtPassword.Text == string.Empty || string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            AddDataClass.InsertData($"update Users set login = '{txtLogin.Text}', accessLevel = {GetSelectedStatusInt()} where id = {UserId}");
                        }
                        else
                        {
                            AddDataClass.InsertData($"update Users set login = '{txtLogin.Text}', password = '{SecurityManager.MD5Protect(txtPassword.Text)}', accessLevel = {GetSelectedStatusInt()} where id = {UserId}");
                        }

                        DataSubmitted = true;
                        this.Close();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Добавить нового пользователя с указанными данными?", "Подтверждение формы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        AddDataClass.InsertData($"insert into Users (login, password, accessLevel) value ('{txtLogin.Text}', '{SecurityManager.MD5Protect(txtPassword.Text)}', {GetSelectedStatusInt()})");
                        DataSubmitted = true;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
                txtPassword.PasswordChar = '*';
            else
                txtPassword.PasswordChar = '\0';
        }
    }
}
