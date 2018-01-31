using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 集成
{
    /* 	作者:    Administrator
	*	时间:    2018/1/21 星期日 14:05:07
	*	描述信息：
	**/
    class PictureMerge
    {
        enum MergePage
        {
            Page0ne = 2526
        }

        /*
         * 
         * 根据路径生成图片
         * */
        public static List<System.Drawing.Image> createImage(List<string> path)
        {
            List<System.Drawing.Image> imgList = new List<System.Drawing.Image>();
            for (int i = 0; i < path.Count; i++)
            {
                System.Drawing.Image img = new Bitmap(path[i]);
                imgList.Add(img);
            }
            return imgList;
        }
        /*参数：图片
       * 返回值：合并后的图片 
       *  组卷页
       * 
       * */
        public static System.Drawing.Image JoinImage(List<System.Drawing.Image> Img1, int page)//拼接图片  
        {
            int imgHeight = 0, imgWidth = 0;
            imgWidth = Img1[0].Width;
            for (int i = 0; i < Img1.Count; i++)
            {
                //if (page == 1)
                //    imgHeight = Img1[i].Height + imgHeight + 516;
                //else
                imgHeight = Img1[i].Height + imgHeight;
            }
            if (imgHeight <= 2526)//图片高度
            {
                Bitmap joinedBitmap = new Bitmap(imgWidth, imgHeight);
                Graphics graph = Graphics.FromImage(joinedBitmap);
                int iHeight = 0;
                for (int i = 0; i < Img1.Count; i++)
                {
                    graph.DrawImage(Img1[i], 0, iHeight, Img1[i].Width, Img1[i].Height);
                    iHeight = iHeight + Img1[i].Height;

                }

                Console.Write(iHeight);
                return joinedBitmap;
            }
            else
            {
                MessageBox.Show("超出长度");
                return null;
            }
        }
        public static System.Drawing.Image PictureBoxShow(List<System.Drawing.Image> Img1)//拼接图片  
        {
            int imgHeight = 0, imgWidth = 0;
            imgWidth = Img1[0].Width;
            for (int i = 0; i < Img1.Count; i++)
            {
                //if (page == 1)
                //    imgHeight = Img1[i].Height + imgHeight + 516;
                //else
                imgHeight = Img1[i].Height + imgHeight;
            }
            imgHeight = imgHeight+Img1.Count*10;
            Bitmap joinedBitmap = new Bitmap(imgWidth, imgHeight);
            Graphics graph = Graphics.FromImage(joinedBitmap);
            int iHeight = 0;
            for (int i = 0; i < Img1.Count; i++)
            {
                graph.DrawImage(Img1[i], 0, iHeight, Img1[i].Width, Img1[i].Height);
                iHeight = iHeight + Img1[i].Height+10;

            }

            Console.Write(iHeight);
            return joinedBitmap;
        }

        /*单个图片转成PDF
         * 参数文件的路径，pdf的路径
         * */

        public static void ConvertJPG2PDF(string jpgfile, string pdf)
        {
            var document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
            using (var stream = new FileStream(pdf, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imageStream);
                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    document.Add(image);
                }

                document.Close();
            }
        }

        /// 图片缩放
        /// </summary>
        /// <param name="bmp">图片</param>
        /// <param name="width">目标宽度，若为0，表示宽度按比例缩放</param>
        /// <param name="height">目标长度，若为0，表示长度按比例缩放</param>
        public static Bitmap GetThumbnail(Bitmap bmp, int width, int height)
        {
            if (width == 0)//0按比例缩放
            {
                width = height * bmp.Width / bmp.Height;
            }
            if (height == 0)
            {
                height = width * bmp.Height / bmp.Width;
            }

            System.Drawing.Image imgSource = bmp;
            Bitmap outBmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(System.Drawing.Color.Transparent);
            // 设置画布的描绘质量   
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new System.Drawing.Rectangle(0, 0, width, height + 1), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            imgSource.Dispose();
            bmp.Dispose();
            return outBmp;
        }

        /*生成缩略图
         * 固定宽高
         * */
        public static System.Drawing.Image GetReducedImage(int width, int height, System.Drawing.Image imageFrom)
        {


            // 源图宽度及高度 
            int imageFromWidth = imageFrom.Width;
            int imageFromHeight = imageFrom.Height;

            // 生成的缩略图实际宽度及高度.如果指定的高和宽比原图大，则返回原图；否则按照指定高宽生成图片
            if (width >= imageFromWidth && height >= imageFromHeight)
            {
                return imageFrom;
            }
            else
            {
                // 生成的缩略图在上述"画布"上的位置
                int X = 0;
                int Y = 0;

                // 创建画布
                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bmp.SetResolution(imageFrom.HorizontalResolution, imageFrom.VerticalResolution);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // 用白色清空 
                    g.Clear(System.Drawing.Color.White);

                    // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // 指定高质量、低速度呈现。 
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    // 在指定位置并且按指定大小绘制指定的 Image 的指定部分。 
                    g.DrawImage(imageFrom, new System.Drawing.Rectangle(X, Y, width, height),
                        new System.Drawing.Rectangle(0, 0, imageFromWidth, imageFromHeight), GraphicsUnit.Pixel);

                    //将图片以指定的格式保存到到指定的位置
                    bmp.Save(@"E:\640x480.png", ImageFormat.Png);
                    return bmp;
                }
            }
        }
     
    }

}


