using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 集成
{
    public class ImageHeigt
    {
        int startHeigt;
        int endHeigt;
        string title;
        public int StartHeigt
        {
            get
            {
                return startHeigt;
            }

            set
            {
                startHeigt = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public int EndHeigt
        {
            get
            {
                return endHeigt;
            }

            set
            {
                endHeigt = value;
            }
        }
    }
}
