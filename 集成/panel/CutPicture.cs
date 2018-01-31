using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 集成.panel
{
    public partial class CutPicture : Form
    {
        double multiple;
        private string sPath1 = "H:/temp/xml";//保存路径
        private string sPath = "H:/temp/图片";//保存路径
        private string cutPath;//切图路径
        int count = 1;
        getSlicingImageWidthAndHeigt convert = new getSlicingImageWidthAndHeigt();
        bool modifyImage = false;//判断是否有涂鸦的操作
        Image image;//用来设置pictureBox1的图片显示，不能省略
        string[] newImageName;
        Image oldImage;
        Image im;
        int page=0;
        List<string> otherImagePath = new List<string>();
        string chooseXml;
        public CutPicture()
        {
            InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            string []XmlPath=Directory.GetFiles("H:/temp/xml", "*.xml");
            foreach (string xml in XmlPath) {
                comboBox1.Items.Add(xml);

            }

        }
        /// <summary>
        /// 选择照片点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void choose_Pic_Click(object sender, EventArgs e)
        {
            show_pic.Enabled = true;
            comboBox1.Visible = true;
            string path = convert.MyOpenFileDialog();

            if (path != null)
            {
                page = 0;
                string[] ImageName = path.Split('\\');
                newImageName = ImageName[ImageName.Length - 1].Split('.');
                image = System.Drawing.Image.FromFile(path);//FromFile里是图片的路径;
                oldImage = image;
                cutPath = path;//切割而成的图片保存的地方
                multiple = ((double)image.Width) / show_pic.Width;//得到原图片和pictureBox1比例，进行图片的缩略和描点的恢复
                MessageBox.Show(multiple + "  " + image.Width + "       " + show_pic.Width);
                Bitmap bit = new Bitmap(image);
                Bitmap getbit = PictureMerge.GetThumbnail(bit, show_pic.Width, 0);//缩略图
                image = getbit;
                show_pic.Image = image;
                convert.count1 = 1;
                convert.imagesPath.Clear();
                convert.imagesHeigt.Clear();
                convert.titles.Clear();
                convert.startAndEnd.Clear();
                convert.count = 1;
                image.Save(path.Split('.')[0] + "缩略图" + ".png");
                MessageBox.Show(path.Split('.')[0] + "缩略图" + ".png");
                convert.imagesPath.Add(path.Split('.')[0] + "缩略图" + ".png");

                convert.images.Add(image);
            }
            else
            {

            }
            //显示下一个
            skinButton2.Visible = true;
            skinLabel2.Visible = true;
            cut_isOk.Visible = true;
            skinButton3.Visible = true;
           
        }
        /// <summary>
        /// 确认切割点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cut_isOk_Click(object sender, EventArgs e)
        {
           
            int i=convert.ConfirmCut(multiple);
            if (i !=0) {
                if (convert.images.Count >= 0)
                    foreach (Image ima in convert.images)
                    {
                        ima.Dispose();
                    }
                string fileaName = convert.imagesPath[page];
                image = System.Drawing.Image.FromFile(fileaName);

                Bitmap bit = new Bitmap(image);
                Bitmap getbit = PictureMerge.GetThumbnail(bit, show_pic.Width, 0);
                image = getbit;
                show_pic.Image = image;

                convert.imagesPath.Remove(convert.imagesPath[convert.imagesPath.Count - 1]);
                convert.imagesPath.Remove(convert.imagesPath[convert.imagesPath.Count - 1]);
                ++count;
                //textBox1.Text = "第" + count + "题";
                //显示下一个
                skinLabel3.Visible = true;
                all_thing_isOk.Visible = true;

            }
            else
            {
                return;

            }
           
        }
        /// <summary>
        /// 完成准备点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void all_thing_isOk_Click(object sender, EventArgs e)
        {
            //cutPath = convert.imagesPath[convert.imagesPath.Count - 1];
           /* for (int i = 1; i < convert.imagesPath.Count - 1; i++)
            {
                System.IO.File.Delete(convert.imagesPath[i]);
            }*/
            //显示下一个
            skinLabel4.Visible = true;
            creat_xml.Visible = true;
        }
        /// <summary>
        /// 创建xml文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void creat_xml_Click(object sender, EventArgs e)
        {
            XmlParse xml = new XmlParse();
            bool flag = xml.createXmlFile(sPath1 + "/"+ newImageName[0]+ ".xml");
            if (flag) { MessageBox.Show("保存成功", "提示"); }
            //显示下一个
            skinLabel5.Visible = true;
            save_data.Visible = true;
        }
        /// <summary>
        /// 撤销按钮点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backout_Click(object sender, EventArgs e)
        {
            string fileName = convert.cancelDraw();
            if (fileName == null)
            {
                return;
            }
            image = System.Drawing.Image.FromFile(fileName);
            show_pic.Image = image;
        }
        /// <summary>
        /// 将数据保存到xml中
        /// </summary>
        List<ImageHeigt> imagesHeigt;
        private void save_data_Click(object sender, EventArgs e)
        {
            bool insert = false;
            imagesHeigt = convert.getImageHeigt();
            XmlParse xml = new XmlParse();

            foreach (ImageHeigt imageH in imagesHeigt)
            {
                MessageBox.Show(imagesHeigt.Count().ToString());
                insert = xml.insertNode(sPath1 + "/" + newImageName[0] + ".xml", imageH.Title, imageH.StartHeigt.ToString(), imageH.EndHeigt.ToString());
            }

            if (insert) { MessageBox.Show("添加成功", "提示"); }
            if (!insert) { MessageBox.Show("添加失败", "提示"); }
            //显示下一个
            skinLabel6.Visible = true;
            cut.Visible = true;
            comboBox1.Items.Add(sPath1 + "/" + newImageName[0] + ".xml");
            comboBox1.Refresh();
        }
        /// <summary>
        /// 切割按钮点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cut_Click(object sender, EventArgs e)
        {
            XmlParse xml = new XmlParse();
            ArrayList list = xml.readAll(sPath1 + "/test.xml");
            foreach (Title t in list)
            {
                //获取编号
                string number = t.Number;
                //获取上限
                string up = t.Up;
                double upInt = double.Parse(up);

                //获取下限
                string down = t.Down;
                double downInt = double.Parse(down);


                //进行计算
                upInt = upInt * oldImage.Height;
                downInt= downInt* oldImage.Height;
                MessageBox.Show(upInt.ToString()+"   "+downInt.ToString());
                string info = ImageUtils.cutImage(cutPath, 0, (int)upInt, oldImage.Width, (int)(downInt - upInt), "题号_" + number, sPath);

                Graphics g = Graphics.FromImage(show_pic.Image);
                g.Clear(Color.White);
                g.Dispose();
                show_pic.Refresh();
                Console.WriteLine("保存信息：" + info);
                skinButton1.Visible = true;
                show_pic.Enabled = false;
            }
        }
        /// <summary>
        /// 是否选中图片涂鸦 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_begin_paint_line_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_begin_paint_line.CheckState == CheckState.Checked)
            {
                modifyImage = true;
            }
            else
            {
                modifyImage = false;
            }
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (modifyImage)
            {

                using (Graphics g = Graphics.FromImage(this.show_pic.Image))
                {

                    int i = 100;
                    Pen p = Pens.Red;
                    if (image != null)
                    {
                        i = image.Width;
                    }
                    g.DrawLine(p, 0, convert.newPoin.Y, i, convert.newPoin.Y);

                    if (!Directory.Exists(sPath))
                    {
                        Directory.CreateDirectory(sPath);
                    }
                    convert.startAndEnd.Add(e.Y);
                    show_pic.Image.Save(sPath + "/" + newImageName[0] + "_" + "picture" + convert.count + ".png", System.Drawing.Imaging.ImageFormat.Bmp);


                    convert.imagesPath.Add(sPath + "/" + newImageName[0] + "_" + "picture" + convert.count + ".png");
                    convert.everyImagePAth.Add(sPath + "/" + newImageName[0] + "_" + "picture" + convert.count + ".png");
                    g.Dispose();
                    //convert.imagesPath.Add(sPath + "/picture" + convert.count + ".png");
                    string fileaName = convert.imagesPath[convert.imagesPath.Count - 1];
                    image = System.Drawing.Image.FromFile(fileaName);
                   /* foreach (Image ima in convert.images)
                    {
                        ima.Dispose();
                    }*/
                    convert.images.Add(image);
                    show_pic.Image = image;
                    convert.count++;

                }
            }
        }


        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            if (modifyImage)
            {
                convert.newPoin = new Point(e.X, e.Y);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (convert.everyImagePAth.Count >= 0)
                foreach (string path in convert.everyImagePAth)
                {
                    System.IO.File.Delete(path);
                }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            //选择一个文件夹
            int pages = 0;
            FolderBrowserDialog P_File_Folder = new FolderBrowserDialog();
            //P_File_Folder.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (P_File_Folder.ShowDialog() == DialogResult.OK)
            {
                /*if (im != null)
                {
                    im.Dispose();
                }*/
               
                XmlParse xml = new XmlParse();
                ArrayList list = xml.readAll(chooseXml);
                string[] filenames = Directory.GetFiles(P_File_Folder.SelectedPath);
                    foreach (Title t in list)
                {
                    /*//获取编号
                    string number = t.Number;
                    //获取上限
                    string up = t.Up;
                    double upInt = double.Parse(up);

                    //获取下限
                    string down = t.Down;
                    double downInt = double.Parse(down);
                    double isOut = downInt;

                    //进行计算
                    upInt = upInt * im.Height;
                    downInt = downInt * im.Height;*/
                    
                        string[] ImageName = filenames[pages].Split('\\');
                        newImageName = ImageName[ImageName.Length - 1].Split('.');
                        im = Image.FromFile(filenames[pages]);
                    int imageWidth= im.Width;
                    int imageHeigh= im.Height;
                    if (im != null) {
                        im.Dispose();
                    }
                    //获取编号
                    string number = t.Number;
                        //获取上限
                        string up = t.Up;
                        double upInt = double.Parse(up);
                            
                        //获取下限
                        string down = t.Down;
                        double downInt = double.Parse(down);
                        double isOut = downInt;

                        //进行计算
                        upInt = upInt * imageHeigh;
                        downInt = downInt * imageHeigh;
                        /*foreach (Title t in list)
                        {
                            //获取编号
                            string number = t.Number;
                            //获取上限
                            string up = t.Up;
                            double upInt = double.Parse(up);

                            //获取下限
                            string down = t.Down;
                            double downInt = double.Parse(down);
                            double isOut = downInt;

                            //进行计算
                            upInt = upInt * im.Height;
                            downInt = downInt * im.Height;*/
                        //MessageBox.Show(upInt.ToString() + "   " + downInt.ToString());
                        //MessageBox.Show(newImageName[0] + "题号_" + number);
                        if (isOut > 0.9)
                        {
                            string info = ImageUtils.cutImage(filenames[pages], 0, (int)upInt, imageWidth, (int)(downInt - upInt), newImageName[0] + "题号_" + number, sPath);
                        pages++;
                        //im.Dispose();
                        continue;
                        }
                        else {
                            string info = ImageUtils.cutImage(filenames[pages], 0, (int)upInt, imageWidth, (int)(downInt - upInt), newImageName[0] + "题号_" + number, sPath);
                        }

                    if (im != null) {
                        im.Dispose();
                    }
                       
                    }


                }
            else
            {

            } 
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            page++;
            //this.show_pic.Image = Image.FromFile(convert.AllImagePath[page]);
            if (convert.AllImagePath.Count > 0)
            {
                MessageBox.Show(convert.AllImagePath.Count.ToString());
                image = System.Drawing.Image.FromFile(convert.AllImagePath[page]);//FromFile里是图片的路径;
                oldImage = image;
                cutPath = convert.AllImagePath[page];//切割而成的图片保存的地方
                multiple = ((double)image.Width) / show_pic.Width;//得到原图片和pictureBox1比例，进行图片的缩略和描点的恢复
                MessageBox.Show(multiple + "  " + image.Width + "       " + show_pic.Width);
                Bitmap bit = new Bitmap(image);
                Bitmap getbit = PictureMerge.GetThumbnail(bit, show_pic.Width, 0);//缩略图
                image = getbit;
                show_pic.Image = image;
                /*convert.count1 = 1;
                convert.imagesPath.Clear();
                convert.imagesHeigt.Clear();
                convert.titles.Clear();
                convert.startAndEnd.Clear();
                convert.count = 1;*/
                image.Save(convert.AllImagePath[page].Split('.')[0] + "缩略图" + ".png");
                MessageBox.Show(convert.AllImagePath[page].Split('.')[0] + "缩略图" + ".png");
                convert.imagesPath.Add(convert.AllImagePath[page].Split('.')[0] + "缩略图" + ".png");
                convert.images.Add(image);
            }
            else {
                return;
            }
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chooseXml = comboBox1.Text;//sd
        }

        private void CutPicture_Load(object sender, EventArgs e)
        {
             //sdsd
        }
    }
}
