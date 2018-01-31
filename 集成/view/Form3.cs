using MySql.Data.MySqlClient;
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
    public partial class Form3 : Form
    {
        public List<string> imgFilePath;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Image> img = new List<Image>();
            imgFilePath = new List<string>();
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.SupportMultiDottedExtensions = true;
            file.ShowDialog();
            foreach (string path in file.FileNames)
            {
                img.Add(Image.FromFile(path));
                imgFilePath.Add(path);
            }
            pictureBox1.BackColor = Color.Black;
            Image aPicture = PictureMerge.PictureBoxShow(img);
            Bitmap c = new Bitmap(aPicture);
            Image b = PictureMerge.GetThumbnail(c, 640, 0);
            this.pictureBox1.Image = b;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] RBValue = new int[30];
            string tem = "";


            foreach (var groupBoxTem in panel2.Controls.OfType<GroupBox>())
            {
                int i = int.Parse(groupBoxTem.Text);
                foreach (var radioButtonTem in groupBoxTem.Controls.OfType<RadioButton>())  //控件枚举包含控件
                {
                    if (radioButtonTem.Text == "对" && radioButtonTem.Checked == true)
                    {

                        RBValue[i - 1] = 1;
                    }

                }

            }

            foreach (int item in RBValue)
            {
                tem += item.ToString() + ",";
            }
            MessageBox.Show(tem);

            upoad(RBValue);

        }
        private void upoad(int[] QueResult)                    //上传mysql
        {
            //上传
            int queNum = 1;
            string stuNum = "789";
            string paperNum = "20180122";
            string imgpath = "*.png";
            int count = 20;



            //初始化
            MySqlConnection con = new MySqlConnection("Data Source=192.168.31.143;User Id=root;Password=root;port=3306;database=hadunlike");
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("连接数据库错误" + ex.Number.ToString());
            }
            string sql = "insert into 做题记录表 values (" + stuNum + "," + queNum + ",Null," + QueResult[queNum - 1] + ",Null,'" + paperNum + "',Null,'" + imgpath + "')";

            while (queNum < count + 1)
            {
                MySqlCommand sqlCom = new MySqlCommand(sql, con);

                try
                {
                    sqlCom.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                queNum++;
            }

            MessageBox.Show("ok");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaseFrm f = new BaseFrm();
            f.Show();
            this.Dispose();
        }

       
    }
}
