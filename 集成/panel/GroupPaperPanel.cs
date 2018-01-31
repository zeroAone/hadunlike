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
using 图片合成.Entity;
using 集成.dao;
using 集成.entity;
using 集成.overwrite;
using 集成.panel.view;
using 集成.util;

namespace 集成.panel
{
    public partial class GroupPaperPanel : Form
    {
        List<string> path = new List<string>();
        List<string> path1 = new List<string>();
        List<Image> imgList = new List<Image>();
        List<Image> showImglist = new List<Image>();
        List<MyPic> pictureBoxList = new List<MyPic>();//左边的PictureBox控件数组集
        List<MyPic> pictureRightBoxlist = new List<MyPic>();//右边的PictureBox控件数组集
        List<Image> haimgList = new List<Image>();//合并的图片集
        List<MyButton> erroButtonRightBoxlist = new List<MyButton>();//错误率按钮控件数组集
        List<MyButton> solutionButtonRightBoxlist = new List<MyButton>();//解析按钮控件数组集
        List<MyButton> carButtonRightBoxlist = new List<MyButton>();//组卷车按钮控件数组集
        List<String> answerList = new List<string>();//答案地址列表
        List<String> testCarList = new List<string>();//组卷车地址列表
        List<List<Image>> pageList = new List<List<Image>>();//页数
        List<Bitmap> bim = new List<Bitmap>();
        List<Image> newImgList = new List<Image>();//转换像素后的图片集
        Boolean isFind = false;//是否以查询
        List<double> errorRateList = new List<double>();
        //Boolean isMerge = false;//是否已经合并
        //int pictureID = 1;
        //int imRheight = 0;
        //int imRheight=0;
        List<Student> stuList;
        List<Test> testList;
        List<TitleDetail> titleList;

        public GroupPaperPanel()
        {
            InitializeComponent();
        }
        private void GroupPaperPanel_Load(object sender, EventArgs e)
        {

            skinPanel3.VerticalScroll.Value = 0;
            //string sqlSearch1 = "select * from 学生表";
            //string sqlSearch2 = "select * from 试卷表";
            //string sqlSearch3 = "SELECT * from 题目表 ORDER BY 错误率 DESC";
            //MySqlConnection mysql = DatabaseDao.getMySqlCon();
            //MySqlCommand mySqlCommand = DatabaseDao.getSqlCommand(sqlSearch1, mysql);
            //MySqlCommand mySqlCommand2 = DatabaseDao.getSqlCommand(sqlSearch2, mysql);
            //MySqlCommand mySqlCommand3 = DatabaseDao.getSqlCommand(sqlSearch3, mysql);
            //mysql.Open();
            //stuList = DatabaseDao.getStudentList(mySqlCommand);
            //testList = DatabaseDao.getTestResultset(mySqlCommand2);
            //titleList = DatabaseDao.getTitleResultset(mySqlCommand3);
            //mysql.Close();
            //skinPanel3.BackColor = Color.Green;
            //skinPanel2.BackColor = Color.Yellow;
            //if (testList.Count != 0)
            //{
            //    Console.WriteLine(testList.Count.ToString());
            //    for (int i = 0; i < testList.Count; i++)
            //        comboBox1.Items.Add(testList[i].TestName);
            //}

            skinPanel3.BackColor = Color.Green;
            skinPanel2.BackColor = Color.Yellow;
        }

        private void check_Pic_Click(object sender, EventArgs e)
        {
            if (!isFind)
            {
                skinLabel2.Visible = true;
                String sqlSearch = "select 图片地址 from 题目信息表   ";

                //MySqlConnection mysql = DatabaseDao.getMySqlCon();
                //MySqlCommand mySqlCommand = DatabaseDao.getSqlCommand(sqlSearch, mysql);
                //mysql.Open();
                //path = DatabaseDao.getPicturePath(mySqlCommand);
                path.Add("H:/temp/图片/题号_A1第1题.png");
                path.Add("H:/temp/图片/题号_A1第2题.png");
                path.Add("H:/temp/图片/题号_A1第3题.png");
                path.Add("H:/temp/图片/题号_A1第4题.png");
                path.Add("H:/temp/图片/题号_A1第5题.png");
                path.Add("H:/temp/图片/题号_A1第6题.png");
                path.Add("H:/temp/图片/题号_A1第7题.png");
                path.Add("H:/temp/图片/题号_A1第8题.png");
                path.Add("H:/temp/图片/题号_A1第9题.png");
                //记得关闭
                //mysql.Close();
                imgList = PictureMerge.createImage(path);
              
                errorRateList.Add(2.3);
                errorRateList.Add(2.5);
                errorRateList.Add(2.8);
                errorRateList.Add(2.9);
                errorRateList.Add(5.9);
                errorRateList.Add(6.8);
                errorRateList.Add(7.8);
                errorRateList.Add(9.5);
                errorRateList.Add(9.5);
               
                answerList.Add("H:/temp/图片/0题号_第2题.png");
                answerList.Add("H:/temp/图片/0题号_第3题.png");
                answerList.Add("H:/temp/图片/0题号_第1题.png");
                answerList.Add("H:/temp/图片/1题号_第2题.png");
                answerList.Add("H:/temp/图片/1题号_第3题.png");
                answerList.Add("H:/temp/图片/1题号_第1题.png");
                answerList.Add("H:/temp/图片/0题号_第2题.png");
                answerList.Add("H:/temp/图片/0题号_第2题.png");
                answerList.Add("H:/temp/图片/0题号_第3题.png");
                ControlCom.createControl(imgList, skinPanel2, showImglist, pictureBoxList, skinPanel3, pictureRightBoxlist, erroButtonRightBoxlist, errorRateList, solutionButtonRightBoxlist, answerList);//生成控件

                skinButton3.Visible = true;
                isFind = true;
            }

        }


        //组卷
        private void combine_btn_Click(object sender, EventArgs e)
        {

            if (pageList.Count != 0)
            {
                //List<Image> newHimg = PictureMerge.transferPicture(haimgList, 1240, 0);
                //Image a = PictureMerge.JoinImage(newHimg, 0);
                //a.Save("H:/temp/组卷/odk.png");
                bim = PictureMerge.JoinImage(pageList);
                for (int i = 0; i < bim.Count; i++)
                {
                    bim[i].Save("H:/temp/组卷/odk" + i + ".png");
                    //PictureMerge.ConvertJPG2PDF("H:/temp/组卷/odk" + i + ".png", "H:/temp/组卷/odk" + i + ".pdf");
                }
                for (int i = 0; i < bim.Count; i++) bim[i].Dispose();
                bim.Clear();
                List<string> a = new List<string>();
                a.Add("H:/temp/组卷/odk0.png");
                a.Add("H:/temp/组卷/odk1.png");
                PictureMerge.convertJpegToPDFUsingItextSharp(a);

                //PictureMerge.convertJpegToPDFUsingItextSharp(a);
                MessageBox.Show("合并完成");
                skinButton1.Visible = true;
                skinButton2.Visible = true;
            }

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            path.Clear();
            showImglist.Clear();
            skinPanel3.Controls.Clear();
            skinPanel3.Refresh();
            pictureRightBoxlist.Clear();
            for (int i = 0; i < pictureBoxList.Count; i++) pictureBoxList[i].Enabled = true;
            //skinButton1.Visible = false;
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            if (pageList.Count != 0)
            {
                PreviewFrom f = new PreviewFrom(pageList);
                f.Show();
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            if (showImglist.Count != 0)
            {
                MessageBox.Show(showImglist.Count.ToString());

                newImgList = PictureMerge.transferPicture(showImglist, 1240, 0);
                pageList = PictureMerge.pageTab(newImgList);
                //MessageBox.Show(showImglist.Count.ToString());
                //haimgList = new List<Image>(showImglist);
                combine_btn.Visible = true;
                skinButton2.Visible = true;
            }
        }

        private void skinButton5_Click(object sender, EventArgs e)
        {
            showImglist = imgList;
        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count != 0)
            {
                for (int i = 0; i < pictureBoxList.Count; i++)
                    testCarList.Add(path[pictureBoxList[i].indexCount]);
                testCar t = new testCar(testCarList);
                t.Show();
            }
        }
    }
}
