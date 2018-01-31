using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 集成.panel
{
    public partial class SolutionPanel : Form
    {
        private string solutionPath;
        public SolutionPanel(string solutionPath)
        {
            InitializeComponent();
            this.solutionPath = solutionPath;
        }
        private void SolutionPanel_Load(object sender, EventArgs e)
        {

            Bitmap b = new Bitmap(solutionPath);
            Image a = PictureMerge.GetThumbnail(b, 736, 0);
            pictureBox1.Image = a;
        }


        private void SolutionPanel_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
