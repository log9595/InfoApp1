using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InfoApp
{
    public partial class CertPasswordForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool IsAuthorized { get; set; } = false;
        private int Id { get; set; } = -1;

        public CertPasswordForm(int id)
        {
            InitializeComponent();

            Id = id;
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection sqlConnection = ConnectionClass.GetStringConnection())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();
                    string query = $"select id from ECPTable where id = {Id} and password = '{SecurityManager.XorEncrypt(txtPass.Text)}'";

                    MySqlCommand sqlCommand = new MySqlCommand(query, sqlConnection);
                    dt.Load(sqlCommand.ExecuteReader());

                    if (dt.Rows.Count > 0)
                    {
                        IsAuthorized = true;
                    }
                    else
                    {
                        IsAuthorized = false;
                    }
                    this.Close();
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
