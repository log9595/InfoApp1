using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Data;
using System.Windows.Forms;

namespace InfoApp
{
    public partial class UsersManageForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UsersManageForm()
        {
            InitializeComponent();
        }

        private void LoadFunc()
        {
            try
            {
                DataTable dataTable = new DataTable();
                string query = "select id, " +
                                     " login, " +
                                     " accessLevel " +
                               " from Users ";

                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                    dataTable = new DataTable();
                    dataTable.Load(sqlCommand.ExecuteReader());

                    dataGridView1.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
        private void UsersManageForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFunc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index < 0)
                    return;

                using (AddUserForm addUserForm = new AddUserForm())
                {
                    addUserForm.ShowDialog();
                    if (addUserForm.DataSubmitted)
                    {
                        LoadFunc();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index < 0)
                    return;

                DataRow dataRow = (dataGridView1.DataSource as DataTable).Rows[dataGridView1.CurrentRow.Index];

                using (AddUserForm addUserForm = new AddUserForm(dataRow))
                {
                    addUserForm.ShowDialog();
                    if (addUserForm.DataSubmitted)
                    {
                        LoadFunc();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index < 0)
                    return;

                DialogResult result = MessageBox.Show($"Удалить пользователя \"{dataGridView1.CurrentRow.Cells["login"].Value.ToString()}\"?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    AddDataClass.InsertData($"delete from Users where id = {dataGridView1.CurrentRow.Cells["id"].Value}");
                    LoadFunc();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "accessLevel" && e.Value != null)
            {
                if (e.Value is int intValue && Enum.IsDefined(typeof(UserAccessLevel), intValue))
                {
                    UserAccessLevel accessLevel = (UserAccessLevel)intValue;
                    e.Value = accessLevel.GetDescription();
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
