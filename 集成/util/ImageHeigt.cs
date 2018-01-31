using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 集成
{
    public class ImageHeigt
    {
        double startHeigt;
        double endHeigt;
        string title;
        public double StartHeigt
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

        public double EndHeigt
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
