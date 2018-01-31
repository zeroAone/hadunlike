using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 集成.view
{
    public partial class bigPdfToSmallPd : Form
    {
        string pdfPath;
        public bigPdfToSmallPd(List<string> path)
        {
            InitializeComponent();
            if (path !=null) {
                foreach (string pa in path)
                {
                    listView1.Items.Add(pa);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错  
            {
                //MessageBox.Show(this.listView1.FocusedItem.SubItems[0].Text);  
                pdfPath = this.listView1.FocusedItem.SubItems[0].Text;//获得的listView的值显示在文本框里  
                MessageBox.Show(pdfPath);
                axAcroPDF1.src = pdfPath;
            }
        }
    }
}
