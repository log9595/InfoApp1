using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Data;
using System.Windows.Forms;

namespace InfoApp
{
    public partial class DocumentTrackingForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();


        public DocumentTrackingForm()
        {
            InitializeComponent();
        }

        private void DocumentTrackingForm_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select ds.id," +
                                     " ds.docName," +
                                     " ds.signDate," +
                                     " CONCAT(et.FIO, ' (', pt.postName, ')') as certOwner," +
                                     " ds.state " +
                               " from DocumentState ds" +
                               " join ECPTable et on et.id = ds.ecp_id " +
                               " left join PostTable pt on et.postID = pt.id" +
                               " order by ds.signDate ";

                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    dataGridView1.DataSource = dt;

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
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "state" && e.Value != null)
            {
                if (e.Value is int intValue && Enum.IsDefined(typeof(DocumentState), intValue))
                {
                    DocumentState documentState = (DocumentState)intValue;
                    e.Value = documentState.GetDescription();
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
