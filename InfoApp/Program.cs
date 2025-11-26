using System;
using System.Windows.Forms;

namespace InfoApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IronPdf.License.LicenseKey = "IRONSUITE.WARFACEPLAY.MAIL.RU.14496-7945C8DC9E-ADR2KQBS6V7PU2Z4-CROPZXLOHVIM-SWRLQDK5V7PP-7BEBMNTBZSVT-BQWVMXSJLVPV-MCUVH6WLJFYM-NXGQ5W-TW7NZWRP6COQUA-DEPLOYMENT.TRIAL-JQZHAF.TRIAL.EXPIRES.25.DEC.2025";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
