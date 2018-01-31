using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 集成.entity
{
    class FalseSubject
    {

        //试卷号
        private int testPaperNum;
        //题号
        private int titleNum;

        private int stuNum;

        public int TestPaperNum
        {
            get
            {
                return testPaperNum;
            }

            set
            {
                testPaperNum = value;
            }
        }

        public int TitleNum
        {
            get
            {
                return titleNum;
            }

            set
            {
                titleNum = value;
            }
        }

        public int StuNum
        {
            get
            {
                return stuNum;
            }

            set
            {
                stuNum = value;
            }
        }
    }
}
