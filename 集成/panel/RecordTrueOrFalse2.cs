using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using 集成.util;
using System.Threading;
using System.Drawing.Imaging;

namespace 集成.panel
{
    public partial class RecordTrueOrFalse2 : Form
    {
        int flag = 0;
        static List<string> imagePath = new List<string>();
        const int WWidth = 1240;
        const int HHeight = 1754;
        public RecordTrueOrFalse2()
        {
            InitializeComponent();
            panelCel();
        }



        Image tem;
        Bitmap tem1;//tem  备份原始合成的图片用做批改的背景  

        Bitmap im1;//im   panel1的背景表格备份
        string mousePoint = "";   //(0,0,0)  左键/右键,X,Y
        string pdfName;                 //
        string imgSavePath;             //       当前exe/试卷名/学生名/imgCut/
        int StuName;
        int TName;                   //试卷名
        List<集成.entity.FalseSubject> flaseSub = new List<entity.FalseSubject>();

        public static void convertJpegToPDFUsingItextSharp()
        {
            List<string> path = imagePath;
            if (path.Count != 0)
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document();

                PdfWriter write = PdfWriter.GetInstance(document, new FileStream(@"H:\temp\1.pdf", FileMode.Append, FileAccess.Write));
                document.Open();
                for (int i = 0; i < path.Count; i++)
                {
                    Bitmap b = new System.Drawing.Bitmap(path[i]);
                    document.SetPageSize(new iTextSharp.text.Rectangle(b.Width + 72f, b.Height + 72f));
                    iTextSharp.text.Image a = iTextSharp.text.Image.GetInstance(b, ImageFormat.Png);
                    document.NewPage();
                    document.Add(a);
                    b.Dispose();
                }
                document.Close();

            }
        }





        private void button1_Click(object sender, EventArgs e) //选择答案
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Title = "选择答案";
            file.Filter = "PDF文件|*.pdf";
            file.ShowDialog();
            axAcroPDF1.src = file.FileName;


        }

        private void button4_Click(object sender, EventArgs e)  //选择文件 
        {
            //读双页pdf
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "选择答卷";
            file.Filter = "PDF文件|*.pdf";
            file.Multiselect = true;
            file.SupportMultiDottedExtensions = true;
            file.ShowDialog();
            if (file.FileName != null)
            {

                TName = 1;
                StuName = 1;
                pdfName = file.FileName;
                pdftoimage(pdfName , TName, 2);   //2页双面pdf到4高的图片tem

                //StuName=file.FileName.Split('')
                // MessageBox.Show(i.ToString());

            }
            pictureBox2.Image = tem;





        }

        private void button2_Click(object sender, EventArgs e)  // 上传数据  
        {




            //var con = dao.DatabaseDao.getMySqlCon();

            //if (str.Length > 1)
            //{
            //    var con = dao.DatabaseDao.getMySqlCon();
            //    foreach (string strtem in str.Split(','))
            //    {
            //        string sql = "insert into 错题表(学号,题目编号) value(1803," + strtem + ")";
            //        dao.DatabaseDao.getSqlCommand(sql, con).ExecuteNonQuery();


            //    }
            //}




        }

        private void button3_Click(object sender, EventArgs e) //保存图片
        {
            flag++;
            if (imagePath.Count > 0&&flag==5) {
                /* bigPdfTiSmallPdf bi = new bigPdfTiSmallPdf();
                 bi.SourceImage = imagePath;
                 Thread t = new Thread(new ThreadStart(bi.TurnTheImageToPdf));
                 t.Start();*/
                Thread t = new Thread(new ThreadStart(convertJpegToPDFUsingItextSharp));
                    t.Start();
                flag = 0;
                //调用  得到错题生成pdf

            }
            string str = "";

            if (mousePoint.Length > 4)
            {
                //int i = 1;
                //foreach (string strtem in mousePoint.Trim(';').Split(';'))
                //{
                for (int i = 0; i < mousePoint.Trim(';').Split(';').Length; i++)
                {
                    string strtem = mousePoint.Trim(';').Split(';')[i];
                    if (strtem.Split(',')[0] == "0")
                    {
                        str += (i+1).ToString() + ",";
                        entity.FalseSubject tem = new entity.FalseSubject();
                        tem.TestPaperNum = TName;
                        tem.TitleNum = i+1;
                        tem.StuNum = StuName;
                        flaseSub.Add(tem);

                    }
                }
                    //i++;
                //}
            }
            MessageBox.Show(str);

            //保存图片-----
            //Image imageTem = new Bitmap(pictureBox2.Image.Width, pictureBox2.Image.Height/4);
            Bitmap img = new Bitmap(pictureBox2.Image);
            int offset = 0;

            for (int ii = 0; ii < pictureBox2.Image.Height; ii += pictureBox2.Image.Height / 4)
            {


                Image imgtem1 = img.Clone(new Rectangle(0, offset, pictureBox2.Image.Width, pictureBox2.Image.Height / 4), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                offset += pictureBox2.Image.Height / 4;

                //输出图片格式1240，1754  放大图片模糊  
                
                int Swidth=595;
                int Sheigh=842;
                Image imgtem2 = new Bitmap(Swidth, Sheigh);
                Graphics g = Graphics.FromImage(imgtem2);
                g.DrawImage(imgtem1, new Rectangle(0, 0, Swidth, Sheigh));
                imgtem1.Dispose();
                

                //imgSavePath=System.Environment.CurrentDirectory;    保存路径名 //输出图片格式1240，1750  放大图片模糊  
                string pathtem = System.Windows.Forms.Application.StartupPath;
                Directory.CreateDirectory(pathtem + "/hdlk/" + StuName.ToString());
                imgtem2.Save(pathtem + "/hdlk/" + StuName + "/" + TName +"-"+ (ii * 4 / pictureBox2.Image.Height).ToString() + ".Png");
                imagePath.Add(pathtem + "/hdlk/" + StuName + "/" + TName + "-" + (ii * 4 / pictureBox2.Image.Height).ToString() + ".Png");


                imgtem2.Dispose();
            }



            //下一套试卷
            if (TName == 4)
            {
                TName = 0;
                StuName++;
            }
            TName++;
            mousePoint = "0,0,0;";
            pdftoimage(pdfName , 2 * TName - 1, 2);
            pictureBox2.Image = tem;
            label2.Text = TName.ToString();



        }

        /*private void convertJpegToPDFUsingItextSharp(object obj)
        {
            throw new NotImplementedException();
        }*/

        private void pdftoimage(string pdfPath, int start, int len)   //acrobat   pdf->image
        {


            int width = 595;// pdfPage.GetSize().X*ral;
            int heigh = 842;// pdfPage.GetSize().Y*ral;
            int offset = 0;


            tem = new Bitmap(width, 4 * heigh);// pdfPage.GetSize().Y);           
            Graphics g = Graphics.FromImage(tem);




            PdfReader pdfReader = new PdfReader(pdfName );
            PdfReaderContentParser parser = new PdfReaderContentParser(pdfReader);

            for (int i = start; i < start + 2; i++)        //从1开始
            {
                MyImageRenderListener listener = new MyImageRenderListener();
                parser.ProcessContent(i, listener);
                using (MemoryStream ms = new MemoryStream(listener.Images[0]))
                {
                    Bitmap a = new Bitmap(842, 1190);//新图片  1240,1754
                    a = new Bitmap(ms);


                    a.Save(@"C:\Users\Administrator\Desktop\桌面老师的文档\1.png");
                    //双页1
                    Bitmap b = a.Clone(new Rectangle(0, 0, a.Width, a.Height / 2), System.Drawing.Imaging.PixelFormat.Format24bppRgb);   //pdf 
                    b.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    g.DrawImage(b, new Rectangle(0, offset, width, heigh));
                    offset += heigh;

                    b.Dispose();
                    //双页2  
                    b = a.Clone(new Rectangle(0, a.Height / 2, a.Width, a.Height / 2), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    b.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    g.DrawImage(b, new Rectangle(0, offset, width, heigh));
                    offset += heigh;
                    a.Dispose();
                    b.Dispose();
                }


            }
            tem1 = new Bitmap(tem, tem.Width, tem.Height);  //tem1  ----------------------------------


            //for (int i = 0; i < listener.Images.Count; ++i)   //从0开始
            //{

            //    //using (FileStream fos = new FileStream(@"C:\Users\Administrator\Desktop\test\result2\1\1\" + i + ".png", FileMode.Create, FileAccess.Write))
            //    //{
            //    //    fos.Write(listener.Images[1], 0, listener.Images[0].Length);
            //    //}
            //    //   //write 图片字节

            //} //write 流      itextsharp listener write


            //Acrobat.CAcroPDDoc pdfDoc = null;
            //Acrobat.CAcroPDPage pdfPage = null;
            //Acrobat.CAcroRect pdfRect = null;
            //Acrobat.CAcroPoint pdfPoint = null;
            //pdfDoc = (Acrobat.CAcroPDDoc)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.PDDoc", "");
            //pdfRect = (Acrobat.CAcroRect)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.Rect", "");


            //pdfDoc.Open(pdfPath);
            //int StuPage = pdfDoc.GetNumPages();

            ////分页pdf


            //pdfPage = (Acrobat.CAcroPDPage)pdfDoc.AcquirePage(0);
            //int ral = 1;
            //int width = 595;// pdfPage.GetSize().X*ral;
            //int heigh = 842;// pdfPage.GetSize().Y*ral;
            ////tem = new Bitmap(width, 2 * heigh);// pdfPage.GetSize().Y);
            ////tem = new Bitmap(width,heigh*4);
            //tem = new Bitmap(pdfPage.GetSize().X * ral / 2, 4 * pdfPage.GetSize().Y * ral);           //picbox.h =image.h  //显示几张图片 
            //Graphics g = Graphics.FromImage(tem);
            //int offset = 0;

            //for (int i = start; i < start + len; i++)
            //{
            //    pdfPage = (Acrobat.CAcroPDPage)pdfDoc.AcquirePage(i);
            //    pdfPoint = (Acrobat.CAcroPoint)pdfPage.GetSize();
            //    pdfRect.Left = 0; pdfRect.Top = 0;
            //    //pdfRect.right =(short)width; pdfRect.bottom = (short)heigh;
            //    pdfRect.right = (short)(ral * pdfPage.GetSize().X); pdfRect.bottom = (short)(ral * pdfPage.GetSize().Y);
            //    //pdfRect.right = 1240; pdfRect.bottom = 1754;
            //    Clipboard.Clear();
            //    pdfPage.CopyToClipboard(pdfRect, 0, 0, (short)(100 * ral));//   Rect:单页是否裁剪
            //    IDataObject clipboardData = Clipboard.GetDataObject(); //acrobat pdf to img


            //    //双页pdf-----

            //    if (clipboardData.GetDataPresent(DataFormats.Bitmap))
            //    {
            //        Bitmap a = (Bitmap)clipboardData.GetData(DataFormats.Bitmap);

            //        //双页1
            //        Bitmap b = a.Clone(new Rectangle(0, 0, pdfRect.right / 2, pdfRect.bottom), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //        g.DrawImage(b, new Rectangle(0, offset, width, heigh));
            //        offset += heigh;

            //        //双页2  
            //        b = a.Clone(new Rectangle(pdfRect.right / 2, 0, pdfRect.right / 2, pdfRect.bottom), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //        g.DrawImage(b, new Rectangle(0, offset, width, heigh));
            //        offset += heigh;

            //        b.Dispose();
            //        a.Dispose();

            //    }

            //    //-----


            //    //单页pdf-----
            //    /*
            //    if (clipboardData.GetDataPresent(DataFormats.Bitmap))
            //    {
            //        Bitmap a = (Bitmap)clipboardData.GetData(DataFormats.Bitmap);

            //        Bitmap b = a.Clone(new Rectangle(0, 0, pdfPage.GetSize().X, pdfPage.GetSize().Y), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //        g.DrawImage(b, new Rectangle(0, 0, width, heigh));
            //        b.Dispose();
            //        a.Dispose();

            //    }
            //    //-----
            //    */ //单页


            //    tem = Image.FromFile(@"D:\zxs\test\1\temp\1.png");
            //    Clipboard.Clear();

            //}  //Acrobat pdf 

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)  //picbox鼠标事件
        {

            Graphics graphics = Graphics.FromImage(pictureBox2.Image);
            if (checkBox1.Checked && (checkBox2.Checked == false))
            {
                if (e.Button == MouseButtons.Left)      //√
                {
                    graphics.DrawLine(new Pen(Color.Red, 2), e.X, e.Y, e.X - 10, e.Y - 10);
                    graphics.DrawLine(new Pen(Color.Red, 2), e.X, e.Y, e.X + 20, e.Y - 20);
                    mousePoint += "1," + e.X.ToString() + ',' + e.Y.ToString() + ';';


                    pictureBox2.Image = tem;

                }
                if (e.Button == MouseButtons.Right)    //X
                {
                    graphics.DrawLine(new Pen(Color.Red, 2), e.X - 10, e.Y + 10, e.X + 10, e.Y - 10);
                    graphics.DrawLine(new Pen(Color.Red, 2), e.X - 10, e.Y - 10, e.X + 10, e.Y + 10);

                    mousePoint += "0," + e.X.ToString() + ',' + e.Y.ToString() + ';';
                    pictureBox2.Image = tem;
                }

                mousePoint = strAsc(mousePoint.Trim(';').Split(';'));
                pannelDraw();
                panel1.Refresh();



            }
            //橡皮
            if (checkBox1.Checked && (checkBox2.Checked == true))
            {
                //删除  批改记录
                for (int i = 1; i < mousePoint.Trim(';').Split(';').Length; i++)
                {
                    int a = int.Parse(mousePoint.Split(';')[i].Split(',')[1]);
                    int b = int.Parse(mousePoint.Split(';')[i].Split(',')[2]);
                    if ((a - e.X) * (a - e.X) < 100 && (b - e.Y) * (b - e.Y) < 100)          //如果勾或叉的线条重合点在橡皮的(+_5)内删除批改点
                    {
                        string str = ";" + mousePoint.Split(';')[i] + ";";
                        mousePoint = mousePoint.Replace(str, ";");
                        break;
                    }
                }

                mousePoint = strAsc(mousePoint.Trim(';').Split(';'));

                //重新画纪录
                graphics.Dispose();
                tem.Dispose();
                tem = new Bitmap(tem1, tem1.Width, tem1.Height);
                graphics = Graphics.FromImage(tem);

                foreach (string i in mousePoint.Substring(6).Trim(';').Split(';'))
                {
                    if (i.Length > 6)
                    {


                        if (i.Split(',')[0] == "1")
                        {
                            graphics.DrawLine(new Pen(Color.Red, 2), int.Parse(i.Split(',')[1]), int.Parse(i.Split(',')[2]), int.Parse(i.Split(',')[1]) - 10, int.Parse(i.Split(',')[2]) - 10);
                            graphics.DrawLine(new Pen(Color.Red, 2), int.Parse(i.Split(',')[1]), int.Parse(i.Split(',')[2]), int.Parse(i.Split(',')[1]) + 20, int.Parse(i.Split(',')[2]) - 20);

                        }
                        else
                        {
                            graphics.DrawLine(new Pen(Color.Red, 2), int.Parse(i.Split(',')[1]) - 10, int.Parse(i.Split(',')[2]) + 10, int.Parse(i.Split(',')[1]) + 10, int.Parse(i.Split(',')[2]) - 10);
                            graphics.DrawLine(new Pen(Color.Red, 2), int.Parse(i.Split(',')[1]) - 10, int.Parse(i.Split(',')[2]) - 10, int.Parse(i.Split(',')[1]) + 10, int.Parse(i.Split(',')[2]) + 10);

                        }
                    }
                }
                pictureBox2.Image = tem;
                pannelDraw();
                panel1.Refresh();

            }
        }

        private void panelCel()  //panel表格  窗口绘丢失  暂在image画
        {
            Image im = new Bitmap(this.panel1.Width, this.panel1.Height);
            Graphics g = Graphics.FromImage(im);
            Font f = new Font("宋体", 10, FontStyle.Regular);
            SolidBrush br = new SolidBrush(Color.Black);

            int h = panel1.Height / 30;

            g.DrawRectangle(new Pen(Color.Black, 2), 0, 0, 120, h * 30);
            g.DrawString("1", f, br, 10, 5);
            g.DrawString("31", f, br, 10 + 60, 5);


            //行
            for (int i = h; i < h * 30; i += h)
            {
                g.DrawLine(new Pen(Color.Black, 1), 0, i, 120, i);
                //表格序数
                g.DrawString(((i + h) / h).ToString(), f, br, 10, i + 5);
                g.DrawString(((i + h) / h + 30).ToString(), f, br, 10 + 60, i + 5);

            }
            //列
            for (int i = 30; i < 120; i += 30)
            {
                g.DrawLine(new Pen(Color.Black, 1), i, 0, i, h * 30);
            }


            this.panel1.BackgroundImage = im;
            im1 = new Bitmap(im);

        }

        private string strAsc(string[] str)//mousePoint   字符串排序 
        {
            string mouse = "";

            if (str.Count() > 2)//至少有2个批改点+1（0，0，0）
            {
                for (int i = 1; i < (str.Count() + 3) / 2; i++)
                {
                    for (int j = i + 1; j < str.Count(); j++)
                    {
                        int str1 = int.Parse(str[i].Split(',')[2]);
                        int str2 = int.Parse(str[j].Split(',')[2]);
                        if (str1 > str2)
                        {
                            string strtem = str[i];
                            str[i] = str[j];
                            str[j] = strtem;

                        }
                    }
                }
            }


            foreach (string strtem1 in str)
            {
                mouse += strtem1 + ";";
            }
            return mouse;

        }

        private void pannelDraw()//panel1结果
        {
            Image im = new Bitmap(im1);
            panel1.BackgroundImage = im;
            Graphics g = Graphics.FromImage(panel1.BackgroundImage);

            int rawH = panel1.Height / 30;//行高
            int rawNum = 1;//当前行数
                           //---
            int colWid = 30; //序号列宽
                             //序号列宽+数值列宽
            int colNum = 2;   //当前列数



            foreach (string str in mousePoint.Trim(';').Split(';'))
            {

                if (str.Length > 6)
                {


                    if (str.Split(',')[0] == "1")
                    {
                        g.DrawLine(new Pen(Color.Red, 2), colWid * (colNum - 1) + 10, rawH * (rawNum) - 3 - 5, colWid * (colNum - 1) + 15, rawH * (rawNum) - 3);  //勾的下顶点到左顶点
                        g.DrawLine(new Pen(Color.Red, 2), colWid * (colNum - 1) + 15, rawH * (rawNum) - 3, colWid * (colNum - 1) + 20, rawH * (rawNum) - 10 - 3);

                    }
                    else
                    {
                        g.DrawLine(new Pen(Color.Red, 2), colWid * (colNum - 1) + 10, rawH * (rawNum) - 3, colWid * (colNum - 1) + 20, rawH * (rawNum) - 10 - 3);  //×的左下顶点画到x的右上
                        g.DrawLine(new Pen(Color.Red, 2), colWid * (colNum - 1) + 10, rawH * (rawNum) - 12 - 3, colWid * (colNum - 1) + 20, rawH * (rawNum) - 3);
                    }

                    rawNum++;
                    if (rawNum > 30) { colNum += 2; rawNum = 1; }  //若超过面板h 

                }

            }


        }


    }


    public class MyImageRenderListener : IRenderListener          //pdf枚举img
    {
        public void RenderText(TextRenderInfo renderInfo) { }
        public void BeginTextBlock() { }
        public void EndTextBlock() { }

        public List<byte[]> Images = new List<byte[]>();
        public List<string> ImageNames = new List<string>();
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            PdfImageObject image = renderInfo.GetImage();
            try
            {
                image = renderInfo.GetImage();
                if (image == null) return;

                ImageNames.Add(string.Format(
                  "Image{0}.{1}", renderInfo.GetRef().Number, image.GetFileType()
                ));
                using (MemoryStream ms = new MemoryStream(image.GetImageAsBytes()))
                {
                    Images.Add(ms.ToArray());
                }
            }
            catch (IOException ie)
            {

                /*
                     * pass-through; image type not supported by iText[Sharp]; e.g. jbig2
                */

            }
        }

       

    }
}
