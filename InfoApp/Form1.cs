using Aspose.Pdf;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace InfoApp
{
    public partial class Form1 : Form
    {
        public class Orgs
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public UserInstance User = new UserInstance();

        DataTable dataTable;
        List<Orgs> orgList = new List<Orgs>();
        DateTime firstDateChangeMonth = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, 1);
        DateTime lastDateChangeMonth = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month));
        DateTime currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        public Form1()
        {
            InitializeComponent();
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
        private void LoadFunc(string strLoad)
        {
            try
            {
                string query = "select et.id," +
                                     " FIO," +
                                     " postName," +
                                     " OrgStructure," +
                                     " room," +
                                     " numbContainer," +
                                     " dateFrom," +
                                     " dateTo," +
                                     " CenterName," +
                                     " comment" +
                               " from ECPTable et" +
                               " left join PostTable pt on et.postID = pt.id" +
                               " left join OrgTable ot on et.orgID = ot.id" +
                               " left join CenterECP ce on et.centerID = ce.id" +
                              $" where deleted = 0" +
                              $" {strLoad}";

                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);

                    dataTable = new DataTable();

                    dataTable.Load(sqlCommand.ExecuteReader());

                    dataGridView1.DataSource = dataTable;

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if ((Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) >= firstDateChangeMonth && Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= lastDateChangeMonth) || Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= currentMonth)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void AdjustToolsToUserAccesLevel()
        {
            if (User.AccessLevel != UserAccessLevel.Administrator)
            {
                connectionProps_Item.Visible = false;
                usersManage_Item.Visible = false;
            }

            if (User.AccessLevel == UserAccessLevel.Read)
            {
                AddForm.Enabled = false;
                btnEdit.Enabled = false;
                btnProlong.Enabled = false;
                btnDelete.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void Authorize()
        {
            User = new UserInstance();

            using (AuthForm authForm = new AuthForm())
            {
                authForm.ShowDialog();
                User = new UserInstance()
                {
                    Id = authForm.User.Id,
                    Login = authForm.User.Login,
                    AccessLevel = authForm.User.AccessLevel
                };
            }

            if (User.Id == 0)
            {
                this.Close();
            }

            AdjustToolsToUserAccesLevel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Authorize();

                LoadOrgstruct();
                LoadFunc("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void AddForm_Click(object sender, EventArgs e)
        {
            try
            {
                using (AddClientForm addClientForm = new AddClientForm())
                {
                    addClientForm.ShowDialog();
                }

                LoadOrgstruct();

                if (cbOrgStruct.SelectedIndex == -1)
                    LoadFunc("");
                else
                {
                    LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbOrgStruct.SelectedIndex == -1)
                    LoadFunc("");
                else
                {
                    LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //dataTable.DefaultView.Sort = "dateTo DESC";
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if ((Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) >= firstDateChangeMonth && Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= lastDateChangeMonth) || Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= currentMonth)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
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
                using (EditClientForm editClientForm = new EditClientForm(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())))
                {
                    editClientForm.ShowDialog();

                    if (cbOrgStruct.SelectedIndex == -1)
                        LoadFunc("");
                    else
                    {
                        LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void BtnProlong_Click(object sender, EventArgs e)
        {
            try
            {
                using (ProlongForm prolongForm = new ProlongForm(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())))
                {
                    prolongForm.ShowDialog();

                    if (cbOrgStruct.SelectedIndex == -1)
                        LoadFunc("");
                    else
                    {
                        LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (InstructForm instForm = new InstructForm())
                {
                    instForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataTable.DefaultView.RowFilter = string.Format($"Convert([FIO], System.String) like '{txtSearch.Text}%'");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) >= firstDateChangeMonth && Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= lastDateChangeMonth) || Convert.ToDateTime(dataGridView1[7, i].Value.ToString()) <= currentMonth)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
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
                if (MessageBox.Show("Вы действительно хотите удалить данную запись?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AddDataClass.InsertData($"update ECPTable set deleted = 1 where id = {dataGridView1.CurrentRow.Cells[0].Value}");

                    if (cbOrgStruct.SelectedIndex == -1)
                        LoadFunc("");
                    else
                    {
                        LoadFunc($"and et.orgID = {orgList[cbOrgStruct.SelectedIndex].id}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenu.Show(pictureBox1, new System.Drawing.Point(e.X - contextMenu.Width, e.Y));
        }

        private void connectionProps_Item_Click(object sender, EventArgs e)
        {
            try
            {
                using (ConnectionSettingsForm settingsForm = new ConnectionSettingsForm())
                {
                    settingsForm.ShowDialog();
                }
                LoadOrgstruct();
                LoadFunc("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void usersManage_Item_Click(object sender, EventArgs e)
        {
            try
            {
                using (UsersManageForm usersManageForm = new UsersManageForm())
                {
                    usersManageForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void changeUser_item_Click(object sender, EventArgs e)
        {
            try
            {
                Authorize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void btnSignDoc_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = "PDF Files | *.pdf";
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Certificate cert = new Certificate();
                    using (CertificateSelectionForm selectionForm = new CertificateSelectionForm())
                    {
                        selectionForm.ShowDialog();
                        cert = selectionForm.Certificate;
                    }

                    // Open PDF document
                    using (Document document = new Aspose.Pdf.Document(openFileDialog.FileName))
                    {
                        // Create a new watermark artifact
                        WatermarkArtifact artifact = new Aspose.Pdf.WatermarkArtifact();
                        artifact.SetTextAndState(
                            $"{cert.FIO}",
                            new Aspose.Pdf.Text.TextState()
                            {
                                FontSize = 50,
                                ForegroundColor = Aspose.Pdf.Color.Blue,
                                BackgroundColor = Aspose.Pdf.Color.BlueViolet,
                                Font = Aspose.Pdf.Text.FontRepository.FindFont("Courier")
                            });
                        // Set watermark properties
                        artifact.ArtifactHorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                        artifact.ArtifactVerticalAlignment = Aspose.Pdf.VerticalAlignment.Top;
                        artifact.Rotation = 0;
                        artifact.Opacity = 0.5;
                        artifact.IsBackground = false;
                        // Add watermark artifact to the first page
                        document.Pages[1].Artifacts.Add(artifact);
                        // Save PDF document
                        document.Save(openFileDialog.FileName);
                    }


                    AddDataClass.InsertData($"insert into DocumentState (docName, ecp_id) values('{System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName)}', {cert.Id})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void btnDocs_Click(object sender, EventArgs e)
        {
            try
            {
                using (DocumentTrackingForm documentTrackingForm = new DocumentTrackingForm())
                {
                    documentTrackingForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
    }
}
