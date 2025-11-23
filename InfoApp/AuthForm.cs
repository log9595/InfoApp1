using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Data;
using System.Windows.Forms;

namespace InfoApp
{
    public partial class AuthForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public UserInstance User = new UserInstance();

        public AuthForm()
        {
            InitializeComponent();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void Authorize()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "select id, " +
                                     " login, " +
                                     " accessLevel " +
                               " from Users " +
                              $" where login = '{txtLogin.Text}' and password = '{SecurityManager.MD5Protect(txtPass.Text)}' ";

                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                    dt.Load(sqlCommand.ExecuteReader());

                    if (dt.Rows.Count > 0)
                    {
                        User = new UserInstance()
                        {
                            Id = (int)dt.Rows[0]["id"],
                            Login = dt.Rows[0]["login"].ToString(),
                            AccessLevel = (UserAccessLevel)dt.Rows[0]["accessLevel"]
                        };
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Авторизация не выполнена. Логин или пароль введены неверно.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Enter)
            {
                Authorize();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            Authorize();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
                txtPass.PasswordChar = '*';
            else
                txtPass.PasswordChar = '\0';
        }
    }
}
