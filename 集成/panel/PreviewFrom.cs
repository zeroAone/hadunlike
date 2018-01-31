using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 集成.util;

namespace 集成.panel
{
    public partial class PreviewFrom : Form
    {
        private List<Image> haimgList = new List<Image>();
        public PreviewFrom(List<List<Image>> haimgList)
        {
            InitializeComponent();
            int fHeight = 0;
            int fWidth = haimgList[0][0].Width;
            for (int i = 0; i < haimgList.Count; i++)
            {
                List<Image> newImgList = PictureMerge.transferPicture(haimgList[i], 578, 0);
                Image a = PictureMerge.PictureBoxShow2(newImgList);
                PictureBox p = ControlCom.createPictureBox(0, fHeight, fWidth, 818, a);
                this.panel1.Controls.Add(p);
                fHeight += 818;
                MessageBox.Show(haimgList.Count.ToString());
            }
        }
    }
}
