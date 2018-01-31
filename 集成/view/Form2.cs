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

namespace 集成.view
{
    public partial class Form2 : Form
    {
        int count = 0;
        List<ImageHeigt> imagesHeigt = null;
        public Form2(List<ImageHeigt> image)
        {
            imagesHeigt = image;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlParse xml = new XmlParse();
            bool flag = xml.createXmlFile("H://test.xml");
            if (flag) { MessageBox.Show("保存成功", "提示"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool insert = false;

            XmlParse xml = new XmlParse();
            MessageBox.Show(imagesHeigt[0].Title);
            foreach (ImageHeigt imageH in imagesHeigt)
            {
                MessageBox.Show(imageH.Title + "   " + imageH.StartHeigt.ToString() + "     " + imageH.EndHeigt.ToString());
                insert = xml.insertNode("H://test.xml", imageH.Title, imageH.StartHeigt.ToString(), imageH.EndHeigt.ToString());
            }

            if (insert) { MessageBox.Show("添加成功", "提示"); }
            if (!insert) { MessageBox.Show("添加失败", "提示"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlParse xml = new XmlParse();
            xml.readAll("H://test.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlParse xml = new XmlParse();
            ArrayList list = xml.readAll("H://test.xml");
            foreach (Title t in list)
            {
                //获取编号
                string number = t.Number;
                //获取上限
                string up = t.Up;
                int upInt = int.Parse(up);
                //获取下限
                string down = t.Down;
                int downInt = int.Parse(down);

                //进行计算

                string info = ImageUtils.cutImage("H://testbefore.png", 0, upInt, 1785, downInt - upInt, "题号_" + number, "H://图片");
                Console.WriteLine("保存信息：" + info);
            }
        }
    }
}
