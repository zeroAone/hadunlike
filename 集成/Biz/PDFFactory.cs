using System;
using System.Collections.Generic; 
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
namespace PDFToolz
{
    public class PDFFactory
    {
        private readonly List<PdfSegment> documents;
        private List<string> pdfPath;

        public void ClearDocuments()
        {
            documents.Clear();
        } 
        
        public void AddDocument(string filename)
        {
            documents.Add(new PdfSegment(new PdfReader(filename), 1, -1));
        }

        public void AddDocument(string filename, int startPage, int endPage)
        {
            documents.Add(new PdfSegment(new PdfReader(filename), startPage, endPage));
        }

        public void AddDocument(Stream pdfStream)
        {
            documents.Add(new PdfSegment(new PdfReader(pdfStream), 1, -1));
        }

        public void AddDocument(Stream pdfStream, int startPage, int endPage)
        {
            documents.Add(new PdfSegment(new PdfReader(pdfStream), startPage, endPage));
        }

        public void AddDocument(byte[] pdfContents)
        {
            documents.Add(new PdfSegment(new PdfReader(pdfContents), 1, -1));
        }

        public void AddDocument(byte[] pdfContents, int startPage, int endPage)
        {
            documents.Add(new PdfSegment(new PdfReader(pdfContents), startPage, endPage));
        }
       
        public void AddDocument(PdfReader pdfDocument)
        {
            documents.Add(new PdfSegment(new PdfReader(pdfDocument), 1, -1));
        }
                
        public void AddDocument(PdfReader pdfDocument, int startPage, int endPage)
        {
            documents.Add(new PdfSegment(new PdfReader(pdfDocument), startPage, endPage));
        }
               
        public void Merge(string outputFilename)
        {
            Merge(new FileStream(outputFilename, FileMode.Create));
        }

        public void Merge(Stream outputStream)
        {
            int rotation = 0;
            if (outputStream == null || !outputStream.CanWrite)
            {
                throw new Exception("Output Stream is null or readonly.");
            }
            Document newDocument = null;
            try
            {
                newDocument = new Document();
                PdfWriter pdfWriter = PdfWriter.GetInstance(newDocument, outputStream);
                if (outputStream.GetType() == typeof(FileStream))
                {
                    pdfWriter.CloseStream = true;
                }
                else
                {
                    pdfWriter.CloseStream = false;
                }
                newDocument.Open();
                PdfContentByte pdfContentByte = pdfWriter.DirectContent;
                foreach (PdfSegment pdi in documents)
                {
                    PdfReader pdfReader = pdi.PdfReader;
                    if (pdi.Skip)
                    {
                        continue;
                    }

                    bool reverse = (pdi.EndPage < pdi.StartPage);

                    for (int nextpage = pdi.StartPage; ; )
                    {
                        newDocument.SetPageSize(pdfReader.GetPageSizeWithRotation(nextpage));
                        newDocument.NewPage();
                        PdfImportedPage importedPage = pdfWriter.GetImportedPage(pdfReader, nextpage);
                        rotation = pdfReader.GetPageRotation(nextpage);
                        pdfContentByte.AddTemplate(importedPage, 0, 0);
                        if (rotation == 90 || rotation == 270)
                        {
                            pdfContentByte.AddTemplate(importedPage, 0, -1f, 1f, 0, 0, pdfReader.GetPageSizeWithRotation(nextpage).Height);
                        }
                        else
                        {
                            pdfContentByte.AddTemplate(importedPage, 1f, 0, 0, 1f, 0, 0);
                        }
                        if (nextpage == pdi.EndPage)
                        {
                            break;
                        }
                        nextpage = nextpage + (reverse ? -1 : 1);
                    }
                }
            }
            finally
            {
                if (outputStream != null)
                {
                    outputStream.Flush();
                }
                if (newDocument != null)
                {
                    newDocument.Close();
                }
               
            }
        }

        public  List<string> Splite(string inputFileName, int pageSize)
        {
            int rotation = 0; 
            PdfReader pdfReader = new PdfReader(inputFileName); 
            string fileName = inputFileName.Substring(0, inputFileName.Length-4); 
            int totalPages  = pdfReader.NumberOfPages;
            int block = 1;
            for (int i = 1; i <= totalPages; block++)
            {
                int tail=block * pageSize;
                if (tail > totalPages) {
                    tail = totalPages;
                }
                string newFileName = fileName + "___"+block.ToString()+".pdf";//原来的 string newFileName = fileName + string.Format("[{0}-{1}].pdf", i,tail);
               // MessageBox.Show(newFileName);
                pdfPath.Add(newFileName);
                FileStream fs = new FileStream(newFileName, FileMode.Create);
                Document newDocument = new Document();
                PdfWriter pdfWriter = PdfWriter.GetInstance(newDocument, fs);
                pdfWriter.CloseStream = true; 
                newDocument.Open();
                PdfContentByte pdfContentByte = pdfWriter.DirectContent;
                for (int j=1;j<=pageSize && i<=totalPages;j++,i++)
                {
                   newDocument.SetPageSize(pdfReader.GetPageSizeWithRotation(i));
                   newDocument.NewPage();
                   PdfImportedPage importedPage = pdfWriter.GetImportedPage(pdfReader,i);
                   rotation = pdfReader.GetPageRotation(i);
                   pdfContentByte.AddTemplate(importedPage, 0, 0);
                   if (rotation == 90 || rotation == 270)
                   {
                       pdfContentByte.AddTemplate(importedPage, 0, -1f, 1f, 0, 0, pdfReader.GetPageSizeWithRotation(i).Height);
                        if (rotation == 90)
                        {
                            pdfContentByte.AddTemplate(importedPage, 0, -1f, 1f, 0, 0, pdfReader.GetPageSizeWithRotation(i).Height);
                        }
                        if (rotation == 270)
                        {
                            pdfContentByte.AddTemplate(importedPage, 0, 1.0F, -1.0F, 0, pdfReader.GetPageSizeWithRotation(i).Width, 0);
                        }
                    }
                   else
                   {
                      pdfContentByte.AddTemplate(importedPage, 1f, 0, 0, 1f, 0, 0);
                   }  
                }
                fs.Flush();
                newDocument.Close();   
            }
            return pdfPath;
        }

        public PDFFactory()
        {
            documents = new List<PdfSegment>();
            pdfPath = new List<string>();
        }
    }
}
