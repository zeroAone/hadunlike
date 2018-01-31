using System;
using System.Collections.Generic; 
using System.Text;
using iTextSharp.text.pdf;

namespace PDFToolz
{
    public class PdfSegment
    {
        /// <summary>
        /// PDF读取器
        /// </summary>
        private PdfReader _pdfReader;
        public  PdfReader PdfReader
        {
            get { return _pdfReader; }
            set { _pdfReader = value; }
        }

        /// <summary>
        /// 开始页码
        /// </summary>
        private int _startPage;
        public int StartPage
        {
            get { return _startPage; }
            set { _startPage = value; }
        }

        /// <summary>
        /// 结束页码
        /// </summary>
        private int _endPage;
        public int EndPage
        {
            get { return _endPage; }
            set { _endPage = value; }
        }

        /// <summary>
        /// 页码不合法，略过
        /// </summary>
        private bool skip = false;
        public bool Skip
        {
            get { return skip; }
            set { skip = value; }
        }
        /// <summary>
        /// PDF Factory操作元素
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="start"></param>
        /// <param name="endPage"></param>
        public PdfSegment(PdfReader reader, int start, int endPage)
        { 
            int pages = reader.NumberOfPages;
            _pdfReader = reader; 
            _startPage = start;
            _endPage = endPage;
            if (start < 0)
            {
                _startPage = start + 1 + pages;
            }
            if (endPage < 0)
            {
                _endPage = 1 + pages + endPage;
            }
            //Check invalid range
            if (_startPage > pages || _endPage > pages)
            {
                skip = true;
            }
        } 
    }   
}
