using System;
using System.Collections.Generic; 
using System.Text;

namespace PDFToolz
{
    public class OperateItem
    {
        /// <summary>
        /// 操作文件
        /// </summary>
        private string _FileName;
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        /// <summary>
        /// 开始页
        /// </summary>
        private int _StartPage;
        public int StartPage
        {
            get { return _StartPage; }
            set { _StartPage = value; }
        }

        /// <summary>
        /// 结束页
        /// </summary>
        private int _EndPage;
        public int EndPage
        {
            get { return _EndPage; }
            set { _EndPage = value; }
        }

        public OperateItem(string fileName, int startPage, int endPage)
        {
            _FileName = fileName;
            _StartPage = startPage;
            _EndPage = endPage;
        }
    }
}
