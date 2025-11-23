using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InfoApp
{
    public partial class PictureBoxForm : Form
    {
        public PictureBoxForm(byte[] imageBytes)
        {
            InitializeComponent();

            OpenImage(imageBytes);
        }

        private void OpenImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);

                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
