using CCWin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 集成.panel;
using 集成.util;

namespace 集成.view
{
    public partial class BaseFrm : CCSkinMain
    {
        public BaseFrm()
        {
            InitializeComponent();
        }
        ArrayList all_panel = new ArrayList();
        Form sub = null;
        private void 切图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in all_panel)
            {
                content_panel.Controls.Remove(frm);
            }
            sub = new CutPicture();
            sub.TopLevel = false;
            sub.Dock = DockStyle.Fill;//把子窗体设置为控件
            sub.FormBorderStyle = FormBorderStyle.None;
            content_panel.Controls.Add(sub);
            all_panel.Add(sub);
            sub.Show();
        }

        private void 组卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in all_panel)
            {
                content_panel.Controls.Remove(frm);
            }
            sub = new GroupPaperPanel();
            sub.TopLevel = false;
            sub.Dock = DockStyle.Fill;//把子窗体设置为控件
            sub.FormBorderStyle = FormBorderStyle.None;
            content_panel.Controls.Add(sub);
            all_panel.Add(sub);
            sub.Show();
        }

        private void 试题对错录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in all_panel)
            {
                content_panel.Controls.Remove(frm);
            }
            sub = new RecordTrueOrFalse2();
            sub.TopLevel = false;
            sub.Dock = DockStyle.Fill;//把子窗体设置为控件
            sub.FormBorderStyle = FormBorderStyle.None;
            content_panel.Controls.Add(sub);
            all_panel.Add(sub);
            sub.Show();
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inPath;
            string outPath = "";
            string[] path;
            OpenFileDialog open = new OpenFileDialog();
            //System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();


            /* if (folder.ShowDialog() == DialogResult.OK)
             {
                 outPath = folder.SelectedPath;
                 //MessageBox.Show(outPath);
             }*/
            if (open.ShowDialog() == DialogResult.OK)
            {

                inPath = open.FileName;
                path = inPath.Split('\\');
                for (int i = 0; i < path.Length - 1; i++)
                {
                    if (i == path.Length - 2)
                    {
                        outPath = outPath + path[i];
                    }
                    else
                    {
                        outPath = outPath + path[i] + "\\";
                    }
                }

                bigPdfTiSmallPdf.pdfToPdf(inPath, outPath);


            }
        }
    }
}
