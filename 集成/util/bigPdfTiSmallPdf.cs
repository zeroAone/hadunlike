using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFToolz;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Drawing2D;
using 集成.view;

namespace 集成.util
{
    class bigPdfTiSmallPdf
    {


        //固定高宽，便于后续处理
        const int WWidth = 1240;
        const int HHeight = 1754;
        static string url;
        static List<System.Drawing.Image> AllName = new List<System.Drawing.Image>();//存放Image对象
        static List<string> pdfToPdfPath = null;//大pdf转换成小pdf，小pdf的路径
        static List<string> imagePath = new List<string>();//小pdf转换成大图片的路径
        static List<string> smallImagePath = new List<string>();//大图片切割成小图片的路径
        static List<string> smallPdfPath = null;//对小pdf的路径进行记录
        public List<string> SourceImage = null;
        public static void pdfToPdf(string path, string outpath)
        {

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请选择文件");
            }
            int pageSize = 1;
            PDFFactory pf = new PDFFactory();
            url = path;
            pdfToPdfPath = pf.Splite(path, pageSize);//---------------------------------------------------------------------------split pdf
            if (pdfToPdfPath != null)
            {

                //拆分文件成功之后接着对pdf转化成图片
                for (int i = 0; i < pdfToPdfPath.Count; i++)
                {
                    string fileName = pdfToPdfPath[i].Substring(0, pdfToPdfPath[i].Length - 4);
                    string imagPath = ConvertPDF2Image(pdfToPdfPath[i], outpath + "/", fileName, 1, 26, System.Drawing.Imaging.ImageFormat.Png, (double)3);  //----------------------------pdf to img
                    imagePath.Add(imagPath);
                }

            }
            else
            {
                MessageBox.Show("拆分文件失败");
            }

            if (imagePath != null)
            {
                Cut(imagePath);  //-------------------------------------------------------------cut
            }

            if (imagePath != null)
            {
                //TurnTheImageToPdf(ref smallImagePath);//---------------------------------------------------------imgtopdf
            }

            for (int i = 0; i < pdfToPdfPath.Count; i++)
            {
                System.IO.File.Delete(pdfToPdfPath[i]);
            }
            for (int i = 0; i < imagePath.Count; i++)
            {
                System.IO.File.Delete(imagePath[i]);
            }
            for (int i = 0; i < smallImagePath.Count; i++)
            {
                System.IO.File.Delete(smallImagePath[i]);
            }

            bigPdfToSmallPd pdf = new bigPdfToSmallPd(smallPdfPath);
            pdf.Show();

        }

       /* private static void TurnTheImageToPdf(ref List<System.Drawing.Image> allName)
        {
            throw new NotImplementedException();
        }*/


        //ConvertPDF2Image(string pdfInputPath, string imageOutputPath, string imageName, int startPageNum, int endPageNum, ImageFormat imageFormat, double resolution)
        //将pdfInputPath改成得到的pdfToPdfPath路径
        /*public static void ConvertPDF2Image(List<string> pdfInputPath,string outpath ,int startPageNum, int endPageNum, ImageFormat imageFormat, double resolution)
        {
            string imageinputPath=pdfInputPath[0];
            string imageOutputPath = outpath;
            string imageName;
            int flag=0;
            Acrobat.CAcroPDDoc pdfDoc = null;
            Acrobat.CAcroPDPage pdfPage = null;
            Acrobat.CAcroRect pdfRect = null;
            Acrobat.CAcroPoint pdfPoint = null;
            pdfDoc = (Acrobat.CAcroPDDoc)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.PDDoc", "");
            if (!pdfDoc.Open(imageinputPath))
            {
                throw new FileNotFoundException();
            }

            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }

            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }
            if (endPageNum > pdfDoc.GetNumPages())
            {
                endPageNum = pdfDoc.GetNumPages();
            }
            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }
            for(int i=0;i< pdfInputPath.Count; i++)
            {
                string fileName = pdfInputPath[i].Substring(0, pdfInputPath[i].Length - 4);
                imageOutputPath = pdfInputPath[i].Substring(0, pdfInputPath[i].Length - 4);//这里有问题
                imageName = fileName;
                flag++;
                for (int j = startPageNum; j <= endPageNum; j++)
                {
                    pdfPage = (Acrobat.CAcroPDPage)pdfDoc.AcquirePage(j - 1);
                    pdfPoint = (Acrobat.CAcroPoint)pdfPage.GetSize();
                    pdfRect = (Acrobat.CAcroRect)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.Rect", "");
                    int imgWidth = (int)((double)pdfPoint.x * resolution);
                    int imgHeight = (int)((double)pdfPoint.y * resolution);
                    pdfRect.Left = 0;
                    pdfRect.right = (short)imgWidth;
                    pdfRect.Top = 0;
                    pdfRect.bottom = (short)imgHeight;
                    pdfPage.CopyToClipboard(pdfRect, 0, 0, (short)(100 * resolution));
                    IDataObject clipboardData = Clipboard.GetDataObject();
                    if (clipboardData.GetDataPresent(DataFormats.Bitmap))
                    {
                        Bitmap pdfBitmap = (Bitmap)clipboardData.GetData(DataFormats.Bitmap);
                        pdfBitmap.Save(Path.Combine(imageOutputPath, imageName)+ ".Jpeg", imageFormat);
                        pdfBitmap.Dispose();
                    }
                }


            }
            if (flag == pdfInputPath.Count) {
                MessageBox.Show("转化成功");
            }
           
        }*/
        //将小pdf转换成图片
        public static string ConvertPDF2Image(string pdfInputPath, string imageOutputPath, string imageName, int startPageNum, int endPageNum, ImageFormat imageFormat, double resolution)

        {
            string imagePath = null;
            Acrobat.CAcroPDDoc pdfDoc = null;

            Acrobat.CAcroPDPage pdfPage = null;

            Acrobat.CAcroRect pdfRect = null;

            Acrobat.CAcroPoint pdfPoint = null;

            pdfDoc = (Acrobat.CAcroPDDoc)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.PDDoc", "");

            if (!pdfDoc.Open(pdfInputPath)) { throw new FileNotFoundException(); }

            if (!Directory.Exists(imageOutputPath)) { Directory.CreateDirectory(imageOutputPath); }

            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }
            if (endPageNum > pdfDoc.GetNumPages())
            {
                endPageNum = pdfDoc.GetNumPages();
            }
            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }

            for (int i = startPageNum; i <= endPageNum; i++)

            {

                pdfPage = (Acrobat.CAcroPDPage)pdfDoc.AcquirePage(i - 1);

                pdfPoint = (Acrobat.CAcroPoint)pdfPage.GetSize();

                pdfRect = (Acrobat.CAcroRect)Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.Rect", "");



                int imgWidth = (int)((double)pdfPoint.x * resolution);

                int imgHeight = (int)((double)pdfPoint.y * resolution);
                pdfRect.Left = 0;

                pdfRect.right = (short)imgWidth;

                pdfRect.Top = 0;

                pdfRect.bottom = (short)imgHeight;


                pdfPage.CopyToClipboard(pdfRect, 0, 0, (short)(100 * resolution));



                IDataObject clipboardData = Clipboard.GetDataObject();



                if (clipboardData.GetDataPresent(DataFormats.Bitmap))

                {
                    Bitmap pdfBitmap = (Bitmap)clipboardData.GetData(DataFormats.Bitmap);

                    pdfBitmap.Save(Path.Combine(imageOutputPath, imageName) + ".Png", imageFormat);

                    pdfBitmap.Dispose();
                }

            }
            pdfDoc.Close();
            imagePath = imageName + ".Png";

            System.Runtime.InteropServices.Marshal.ReleaseComObject(pdfPage);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pdfRect);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pdfDoc);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pdfPoint);
            return imagePath;

        }

        //大图切割成小图
        public static void Cut(List<string> imgPath)
        {
            int flag = 0;
            int fla = 0;
            Bitmap bitmap = null;
            string outPath;
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
            for (int i = 0; i < imagePath.Count; i++)
            {
                bitmap = new Bitmap(imagePath[i]);
                outPath = imagePath[i].Substring(0, pdfToPdfPath[i].Length - 4);
                for (int j = 0; j < 2; j++)
                {

                    if (flag == 0)
                    {
                        rect = new System.Drawing.Rectangle(0, 0, bitmap.Width / 2, bitmap.Height);
                        flag = 1;
                    }
                    else if (flag == 1)
                    {
                        rect = new System.Drawing.Rectangle(bitmap.Width / 2, 0, bitmap.Width / 2, bitmap.Height);
                        flag = 0;
                        fla = 1;
                    }
                    // Bitmap nb = bitmap.Clone(rect, System.Drawing.Imaging.PixelFormat.Format16bppRgb565);
                    // Stream ms = new MemoryStream();
                    //nb.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    System.Drawing.Image ima = bitmap.Clone(rect, PixelFormat.Format16bppArgb1555);
                    ima.Save(outPath + "_" + j.ToString() + ".Png");
                    ima.Dispose();
                    // nb.Dispose();
                    //nb = null;
                    smallImagePath.Add(outPath + "_" + j.ToString() + ".Png");
                }
                if (fla == 1)
                {
                    bitmap.Dispose();
                    bitmap = null;
                    fla = 0;
                }

            }
            if (bitmap != null)
                bitmap.Dispose();

        }

        //对图片转化成pdf

        /*public static void TurnTheImageToPdf(ref List<string> SourceImage)
        {
            int flag = 1;
            int count = 1;
            string FileName = SourceImage[0].Substring(0, pdfToPdfPath[0].Length - 4);//转换出来的pdf的名字
                                                                                      //ChangeTheImageToS(ref SourceImage,count);
            Bitmap bmImage = null;
            Bitmap src = null;
            Graphics g = null;
            Document document = new Document();
            document.SetPageSize(new iTextSharp.text.Rectangle(WWidth + 72f, HHeight + 72f));
            PdfWriter write =null;
            iTextSharp.text.Image jpg;
            for (int n = 0; n < SourceImage.Count; n++) {
                src = new Bitmap(SourceImage[n]);
                bmImage = new Bitmap(WWidth, HHeight);
                g = Graphics.FromImage(bmImage);
                g.InterpolationMode = InterpolationMode.Low;
                g.DrawImage(src, new System.Drawing.Rectangle(0, 0, bmImage.Width, bmImage.Height), new System.Drawing.Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);
                g.Dispose();
                src.Dispose();


                AllName.Add(bmImage);
                if (count % 4 == 0)
                {
                    write = PdfWriter.GetInstance(document, new FileStream(FileName + "_" + flag.ToString() + ".pdf", FileMode.Create, FileAccess.Write));
                    document.Open();
                    for (int i = 0; i < AllName.Count; i++)
                    {
                            jpg = iTextSharp.text.Image.GetInstance(AllName[i], ImageFormat.Png);
                            document.NewPage();
                            document.Add(jpg);
                    }
                             AllName.Clear();

                             bmImage.Dispose();
                       GC.Collect();
                    bmImage = null;
                             flag++;
                    count++;
                }
                else {
                    count++;
                }

            }
            if (document != null && document.IsOpen())
            {

                document.Close();
            }
            if (write != null)
            {
                write.Close();
            }


        }*/
        //change all the image to standard
        /*private static void ChangeTheImageToS(ref List<string> ImageName,int count)
        {

            for (int i = count; i < ImageName.Count; ++i)
            {
                Bitmap src = new Bitmap(ImageName[i]);
                Bitmap bmImage = new Bitmap(WWidth, HHeight);
                Graphics g = Graphics.FromImage(bmImage);
                g.InterpolationMode = InterpolationMode.Low;
                g.DrawImage(src, new System.Drawing.Rectangle(0, 0, bmImage.Width, bmImage.Height), new System.Drawing.Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);
                g.Dispose();
                AllName.Add(bmImage);
                src.Dispose();
                bmImage.Dispose();
                bmImage = null;
                count++;
            }
        }*/

        //4张小图拼接成一个pdf
        public  void TurnTheImageToPdf()
        { 
            //smallPdfPath = new List<string>();
                string FileName = SourceImage[0].Substring(0, SourceImage[0].Length - 4);//转换出来的pdf的名字
                smallPicToPdf(ref SourceImage);
                //ChangeTheImageToS(ref SourceImage,count);
                Document document = new Document();
               // document.SetPageSize(new iTextSharp.text.Rectangle(WWidth + 72f, HHeight + 72f));
                document.SetPageSize(new iTextSharp.text.Rectangle(WWidth, HHeight));
      
                PdfWriter write = PdfWriter.GetInstance(document, new FileStream(FileName + ".pdf", FileMode.Append, FileAccess.Write));
                //smallPdfPath.Add(url + "-" + flag.ToString() + ".pdf");
                document.Open();
                iTextSharp.text.Image jpg;
                for (int i = 0; i < AllName.Count; i++)
                {

                    jpg = iTextSharp.text.Image.GetInstance(AllName[i], ImageFormat.Png);
                    document.NewPage();
                    document.Add(jpg);

                }

                try
                {
                    if (document != null && document.IsOpen())
                    {

                        document.Close();
                    }
                    if (write != null)
                    {
                        write.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.Out.Write(ex.ToString());
                }
                finally
                {
              
                }


        }

        private static void smallPicToPdf(ref List<string> ImageName)
        {

            Bitmap bi =null;
            for (int i=0 ; i < ImageName.Count; i++)
            {
               /* if (bi != null) {
                    bi.Dispose();
                }*/
                Bitmap src = new Bitmap(ImageName[i]);
                Bitmap bmImage = new Bitmap(WWidth, HHeight);
                bi = bmImage;
                Graphics g = Graphics.FromImage(bmImage);
                g.InterpolationMode = InterpolationMode.Low;
                g.DrawImage(src, new System.Drawing.Rectangle(0, 0, bmImage.Width, bmImage.Height), new System.Drawing.Rectangle(0, 0, src.Width, src.Height), GraphicsUnit.Pixel);
                g.Dispose();
                src.Dispose();
                AllName.Add(bmImage); 
            }

            /*if (bi != null)
            {
                bi.Dispose();
            }*/

        }

    }
}
