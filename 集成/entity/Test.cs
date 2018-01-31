using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 集成.entity
{
    /* 	作者:    Administrator
	*	时间:    2018/1/30 星期二 22:24:45
	*	描述信息：
	**/
    public class Test
    {
        private int testID;//试卷编号
        private string testName;//试卷名称
        private string testAddress;//试卷地址
        private string testAnswer;//试卷答案
        public Test() { }

        public int TestID
        {
            get
            {
                return testID;
            }

            set
            {
                testID = value;
            }
        }

        public string TestName
        {
            get
            {
                return testName;
            }

            set
            {
                testName = value;
            }
        }

        public string TestAddress
        {
            get
            {
                return testAddress;
            }

            set
            {
                testAddress = value;
            }
        }

        public string TestAnswer
        {
            get
            {
                return testAnswer;
            }

            set
            {
                testAnswer = value;
            }
        }
    }
}
