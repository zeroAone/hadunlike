using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 集成
{
    class Title
    {
        private string number;
        private string up;
        private string down;
        //快捷键Ctrl+R、Ctrl+E
        public string Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public string Up
        {
            get
            {
                return up;
            }

            set
            {
                up = value;
            }
        }

        public string Down
        {
            get
            {
                return down;
            }

            set
            {
                down = value;
            }
        }

        public Title()
        {

        }
    }
}
