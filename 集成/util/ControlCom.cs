using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 集成.overwrite;
using 集成.panel;

namespace 集成.util
{
    /* 	作者:    Administrator
	*	时间:    2018/1/25 星期四 16:23:12
	*	描述信息：
	**/
    public class ControlCom
    {
        //产生Panel控件
        public static Panel createPanel(int localX, int localY, int width, int height)
        {
            Panel p = new Panel();
            p.Location = new Point(localX, localY);
            p.Size = new Size(width, height);
            p.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            p.BackColor = Color.White;

            return p;
        }
        //产生PictureBox控件
        public static MyPic createPictureBox(int localX, int localY, int width, int height, Image img)
        {
            MyPic p = new MyPic();
            p.Location = new Point(localX, localY);

            p.Size = new Size(width, height);
            p.Image = img;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Enabled = true;
            //p.CreateGraphics().DrawLine(Pens.Red, p.Width / 2, 0, p.Width / 2, p.Height);
            return p;
        }
        //产生Button控件
        public static MyButton createButton(string txt, int localX, int localY, int width, int height)
        {
            MyButton b = new MyButton();
            b.Text = txt;
            b.Location = new Point(localX, localY);
            b.Size = new Size(width, height);
            b.BackColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;//C# 如何去掉button按钮的边框线
            b.ForeColor = Color.Red;
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
        //解析事件
        private static void solution_MouseClick(string s, string solutionPath)
        {
            MessageBox.Show(s);
            if (solutionPath != "")
            {
                SolutionPanel f = new SolutionPanel(solutionPath);
                f.Show();
            }

        }
        //加入组卷车事件
        private static void join_MouseClick(string s)
        {
            MessageBox.Show("加入组卷车");
        }

        //特别提醒事件
        private static void remind_MouseClick(string s)
        {
            MessageBox.Show("特别提醒");
        }
        //组卷次数事件
        private static void count_MouseClick(string s)
        {
            MessageBox.Show("组卷次数");
        }

        //错误率事件
        private static void error_MouseClick(string s, double a)
        {
            MessageBox.Show("错误率:" + a.ToString());

        }
        //右边的PictureRightBox点击事件  修改showImglist 移除控件  刷新panel
        public static void pictureBoxRight_MouseClick(int i, List<Image> showImglist, List<Image> imgList, List<MyPic> pictureRightBoxlist, Panel panl, List<MyPic> pictureBoxList)
        {
            //MessageBox.Show(showImglist.Count.ToString());
            for (int j = 0; j < pictureBoxList.Count; j++)
                if (pictureBoxList[j].indexCount == i) pictureBoxList[j].Enabled = true;
            for (int j = 0; j < showImglist.Count; j++)
            {
                panl.VerticalScroll.Value = 0;
                //if (pictureBoxList[j].indexCount == i) pictureBoxList[j].Enabled = true;
                if (pictureRightBoxlist[j].indexCount == i)
                {
                    panl.Controls.Remove(pictureRightBoxlist[j]);
                    //pictureRightBoxlist[j].Visible = false;
                    pictureRightBoxlist[j].Dispose();//清空这个控件在程序中的内存
                    panl.Refresh();
                    pictureRightBoxlist.Remove(pictureRightBoxlist[j]);
                    showImglist.Remove(imgList[i]);
                }

            }
            int heights = 0;
            for (int jl = 0; jl < pictureRightBoxlist.Count; jl++)
            {
                pictureRightBoxlist[jl].Location = new Point(0, heights);
                heights += pictureRightBoxlist[jl].Image.Height;
            }
            //MessageBox.Show(showImglist.Count.ToString());

        }

        /*左边PictureBox点击选中事件   
         * 参数：图片  把图片传递到   showImglist 中   标记已选择
         * i   标记参数    用于识别
         * panel   面板  用于添加picturebox控件
         * pictureRightBoxlist
         * imgList
         * **/
        public static void pictureBox_MouseClick(PictureBox pb, Image img, List<Image> showImglist, int i, Panel panel, List<MyPic> pictureRightBoxlist, List<Image> imgList, List<MyPic> pictureBoxList)
        {
            //MessageBox.Show(i.ToString());
            if (pb.Enabled == true)
            {
                int imgheight = 0;
                if (pictureRightBoxlist.Count != 0)
                {
                    showImglist.Add(img);
                    for (int j = 0; j < pictureRightBoxlist.Count; j++) imgheight += pictureRightBoxlist[j].Image.Height;


                    createRightControl(img, panel, pictureRightBoxlist, i, imgheight, showImglist, imgList, pictureBoxList);
                    //MessageBox.Show(pictureRightBoxlist.Count.ToString());


                }
                else if (pictureRightBoxlist.Count == 0)
                {
                    showImglist.Add(img);
                    createRightControl(img, panel, pictureRightBoxlist, i, 0, showImglist, imgList, pictureBoxList);
                }
                pb.Enabled = false;
            }

        }

        /*参数;图片列表
       * 参数：面板
       * 参数传递：showlist    用于保存已选择的图片
       * 参数：pictureBox   用于保存生成picturebox的列表
       * 参数：panel    传递主面板 过来   用于把控件添加到主面板中
       * 参数：pictureRightBoxlist    用于保存  右边生成的picturebox的面板
       * 参数：erroButtonRightBoxlist  用于保存   错误率的按钮列表
       * 参数：erro_count  错误率列表
       * 参数：solutionButtonRightBoxlist  解析按钮     把解析的按钮保存到这个列表 中
       * 参数：answerList    答案的地址    用于传递到解析按钮中   处理事件
       * 添加控件
       * */
        public static void createControl(List<Image> imgList, Panel panel1, List<Image> showImglist, List<MyPic> pictureBoxList, Panel panel, List<MyPic> pictureRightBoxlist, List<MyButton> erroButtonRightBoxlist, List<double> erro_count, List<MyButton> solutionButtonRightBoxlist, List<String> answerList)
        {

            int imgheight = 0;
            for (int i = 0; i < imgList.Count; i++)
            {
                Bitmap aa = new Bitmap(imgList[i]);
                Image a = PictureMerge.GetThumbnail(aa, 1240, 0);
                Bitmap ac = new Bitmap(a);
                Image b = PictureMerge.GetThumbnail(ac, 578, 0);
                Panel p = createPanel(0, imgheight, 578, b.Height + 25);

                MyPic pb = createPictureBox(0, 0, 578, b.Height, b);
                pb.indexCount = i;

                pb.MouseClick += (e, f) => pictureBox_MouseClick(pb, imgList[pb.indexCount], showImglist, pb.indexCount, panel, pictureRightBoxlist, imgList, pictureBoxList);
                pictureBoxList.Add(pb);

                p.CreateGraphics().DrawLine(Pens.Red, 0, b.Height, 578, b.Height);

                //graph.DrawLine(new Pen(Color.Red, 2), new System.Drawing.Font("宋体", 50, FontStyle.Bold), Brushes.DimGray, 0, iHeight);
                MyButton solution_Button = createButton("解析", 0, pb.Height + 1, 80, 23);
                if (i < answerList.Count)
                    solution_Button.solutionPath = answerList[i];
                solution_Button.MouseClick += (e, f) => solution_MouseClick("解析", solution_Button.solutionPath);//添加事件
                solutionButtonRightBoxlist.Add(solution_Button);
                Button join_Button = createButton("加入组卷车", 120, pb.Height + 1, 80, 23);
                join_Button.MouseClick += (e, f) => join_MouseClick("加入组卷车");

                Button remind_Button = createButton("特别提醒", 240, pb.Height + 1, 80, 23);
                remind_Button.MouseClick += (e, f) => remind_MouseClick("特别提醒");

                Button count_Button = createButton("组卷次数", 360, pb.Height + 1, 80, 23);
                count_Button.MouseClick += (e, f) => count_MouseClick("组卷次数");

                MyButton error_Button = createButton("错误率" + erro_count[i], 478, pb.Height + 1, 80, 23);
                if (i < erro_count.Count)
                    error_Button.error_Count = erro_count[i];
                error_Button.MouseClick += (e, f) => error_MouseClick("错误率", error_Button.error_Count);
                erroButtonRightBoxlist.Add(error_Button);

                //p.Size = new Size(578, b.Height + 23);
                p.Controls.Add(solution_Button);
                p.Controls.Add(join_Button);
                p.Controls.Add(remind_Button);
                p.Controls.Add(count_Button);
                p.Controls.Add(error_Button);
                p.Controls.Add(pb);
                if (p != null)
                    panel1.Controls.Add(p);
                imgheight += b.Height + 50;
            }
        }

        /*参数：图片 设置picturebox的图片
         * 参数：面板 传递面板2 修改里面的控件
         * 参数;控件列表   管理PictureBox控件
         * 参数：i   传递标记
         * 参数：imgheight    用来设置picturebox控件的位置
         * 参数：showImglist   管理显示的图片
         * 参数：imgList   管理显示的图片在imgList的索引
         * 添加控件
         * */
        public static void createRightControl(Image img, Panel panel1, List<MyPic> pictureRightBoxlist, int i, int imgheight, List<Image> showImglist, List<Image> imgList, List<MyPic> pictureBoxList)
        {
            Bitmap ac = new Bitmap(img);
            Image b = PictureMerge.GetThumbnail(ac, 578, 0);
            MyPic pb = createPictureBox(0, imgheight, 578, b.Height, b);
            pb.indexCount = i;
            pictureRightBoxlist.Add(pb);
            panel1.VerticalScroll.Value = 0;
            panel1.Controls.Add(pb);
            panel1.Refresh();
            pb.MouseClick += (e, f) => pictureBoxRight_MouseClick(pb.indexCount, showImglist, imgList, pictureRightBoxlist, panel1, pictureBoxList);
            //MessageBox.Show(pb.Location.ToString());



        }
    }
}
