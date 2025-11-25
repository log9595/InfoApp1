using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InfoApp
{
    public partial class EditClientForm : Form
    {
        public class Posts
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Orgs
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class Centers
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class EditData
        {
            public int id { get; set; }
            public string FIO { get; set; }
            public int postID { get; set; }
            public int orgID { get; set; }
            public string room { get; set; }
            public string numbContainer { get; set; }
            public DateTime dateFrom { get; set; }
            public DateTime dateTo { get; set; }
            public int centerID { get; set; }
            public string password { get; set; }
            public byte[] imageBytes { get; set; } = new byte[] { };
            public string comment { get; set; }
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        List<Posts> postList = new List<Posts>();
        List<Orgs> orgList = new List<Orgs>();
        List<Centers> centerList = new List<Centers>();
        List<EditData> editList = new List<EditData>();
        int _id = 0;

        public EditClientForm(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void LoadPost()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select * from PostTable", sqlConnection);

                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    postList.Clear();

                    while (reader.Read())
                    {
                        postList.Add(new Posts { id = reader.GetInt32(0), name = reader.GetString(1) });
                    }
                }

                cbPost.DataSource = null;
                cbPost.DataSource = postList;
                cbPost.DisplayMember = "name";
                cbPost.ValueMember = "id";
                cbPost.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void LoadOrgstruct()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select * from OrgTable", sqlConnection);

                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    orgList.Clear();

                    while (reader.Read())
                    {
                        orgList.Add(new Orgs { id = reader.GetInt32(0), name = reader.GetString(1) });
                    }
                }

                cbOrgStruct.DataSource = null;
                cbOrgStruct.DataSource = orgList;
                cbOrgStruct.DisplayMember = "name";
                cbOrgStruct.ValueMember = "id";
                cbOrgStruct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void LoadCenter()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand("select * from CenterECP", sqlConnection);

                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    centerList.Clear();

                    while (reader.Read())
                    {
                        centerList.Add(new Centers { id = reader.GetInt32(0), name = reader.GetString(1) });
                    }
                }

                cbCenter.DataSource = null;
                cbCenter.DataSource = centerList;
                cbCenter.DisplayMember = "name";
                cbCenter.ValueMember = "id";
                cbCenter.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                /*-Load PostName-*/
                LoadPost();
                /*---------------*/

                /*-Load OrgStructure-*/
                LoadOrgstruct();
                /*-------------------*/

                /*--Load Center--*/
                LoadCenter();
                /*---------------*/
                LoadFunction();

                if (editList[0].imageBytes.Length <= 0)
                {
                    btnOpenImage.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnAddPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPost.Text != "" && cbPost.SelectedIndex == -1)
                {
                    string post = cbPost.Text;
                    AddDataClass.InsertData($"insert into PostTable (postName) value ('{post}')");
                    LoadPost();
                    cbPost.Text = post;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnAddOrg_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbOrgStruct.Text != "" && cbOrgStruct.SelectedIndex == -1)
                {
                    string depart = cbOrgStruct.Text;
                    AddDataClass.InsertData($"insert into OrgTable (OrgStructure) value ('{depart}')");
                    LoadOrgstruct();
                    cbOrgStruct.Text = depart;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void LoadFunction()
        {
            try
            {
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();
                    string query = "select id, FIO, postID, orgID, room, numbContainer, dateFrom, dateTo, centerID, password, imageBytes, comment from ECPTable" +
                                  $" where id = {_id}";

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                    MySqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        editList.Add(new EditData { id = reader.GetInt32(0), FIO = reader.GetString(1), postID = reader.GetInt32(2), orgID = reader.GetInt32(3), room = reader.GetString(4), numbContainer = reader.GetString(5), dateFrom = reader.GetDateTime(6), dateTo = reader.GetDateTime(7), centerID = reader.GetInt32(8), password = SecurityManager.XorDecrypt(Encoding.UTF8.GetString(reader.GetFieldValue<byte[]>(9))), imageBytes = reader.GetFieldValue<byte[]>(10), comment = reader.GetString(11) });
                    }
                }

                txtFIO.Text = editList[0].FIO;
                cbPost.SelectedValue = editList[0].postID;
                cbOrgStruct.SelectedValue = editList[0].orgID;
                txtRoom.Text = editList[0].room;
                txtBox.Text = editList[0].numbContainer;
                dateFrom.Value = editList[0].dateFrom;
                dateTo.Value = editList[0].dateTo;
                cbCenter.SelectedValue = editList[0].centerID;
                txtPassword.Text = editList[0].password;
                txtComment.Text = editList[0].comment;

                if (editList[0].imageBytes.Length > 0)
                    btnOpenImage.Enabled = true;
                else
                    btnOpenImage.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Подтверждение формы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                    {
                        string query = $"update ECPTable set FIO = '{txtFIO.Text}', postID = {postList[cbPost.SelectedIndex].id}, orgID = {orgList[cbOrgStruct.SelectedIndex].id}, room = '{txtRoom.Text}', numbContainer = '{txtBox.Text}', dateFrom = '{dateFrom.Value:yyyy-MM-dd}', dateTo = '{dateTo.Value:yyyy-MM-dd}', centerID = {centerList[cbCenter.SelectedIndex].id}, password = '{SecurityManager.XorEncrypt(txtPassword.Text)}', imageBytes = @imageBytes, comment = '{txtComment.Text}' where id = {_id}";
                        if (sqlConnection.State == ConnectionState.Closed)
                            sqlConnection.Open();

                        using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                        {
                            cmd.Parameters.Add("@imageBytes", MySqlDbType.LongBlob).Value = editList[0].imageBytes;
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Внесенные изменения успешно сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAddCenter_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCenter.Text != "" && cbCenter.SelectedIndex == -1)
                {
                    string center = cbCenter.Text;
                    AddDataClass.InsertData($"insert into CenterECP (CenterName) value ('{center}')");
                    LoadCenter();
                    cbCenter.Text = center;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void btnCreatePass_Click(object sender, EventArgs e)
        {
            string passwordString = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtFIO.Text))
                    return;

                if (txtFIO.Text.Trim().Split(' ').Length < 2)
                {
                    MessageBox.Show("Необходимо указать хотя бы Фамилию и Имя", "Неверные входные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                passwordString = ECPPassGenerator.Process(txtFIO.Text);

                if (passwordString is null)
                {
                    MessageBox.Show("Не удалось сгенерировать пароль из заданной строки.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (passwordString != null)
                    txtPassword.Text = passwordString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files | *.png; *.jpg";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                editList[0].imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                btnOpenImage.Enabled = true;
            }
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            using (PictureBoxForm pictureBoxForm = new PictureBoxForm(editList[0].imageBytes))
            {
                pictureBoxForm.ShowDialog();
            }
        }
    }
}
