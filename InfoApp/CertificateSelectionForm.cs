using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace InfoApp
{
    public partial class CertificateSelectionForm : Form
    {
        public class Orgs
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Certificate Certificate { get; set; } = new Certificate();

        DataTable dataTable;
        List<Orgs> orgList = new List<Orgs>();
        DateTime firstDateChangeMonth = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, 1);
        DateTime lastDateChangeMonth = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month));
        DateTime currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

        public CertificateSelectionForm()
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
                                     " OrgStructure " +
                               " from ECPTable et" +
                               " left join PostTable pt on et.postID = pt.id" +
                               " left join OrgTable ot on et.orgID = ot.id" +
                               " left join CenterECP ce on et.centerID = ce.id" +
                              $" where deleted = 0 and dateTo > now() " +
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
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
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

        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index < 0)
                    return;

                DataGridViewRow row = dataGridView1.CurrentRow;
                Certificate = new Certificate()
                {
                    Id = (int)row.Cells["id"].Value,
                    FIO = row.Cells["FIO"].Value.ToString(),
                    PostName = row.Cells["postName"].Value.ToString(),
                    OrgStructName = row.Cells["OrgStructure"].Value.ToString()
                };

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }

        private void CertificateSelectionForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                LoadOrgstruct();
                LoadFunc("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Debug("\n/--------------------------------------------------------------------/\n" + ex.StackTrace + "\n//----------------------------//\n" + ex.Message + "\n\n");
            }
        }
    }
}
