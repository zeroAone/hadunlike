using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图片合成.Entity
{
    /* 	作者:    Administrator
	*	时间:    2018/1/22 星期一 14:29:23
	*	描述信息：题目信息表
	**/
    public class TitleDetail
    {
        private int ID;
        private int titleID;//题目编号
        private int testID;//试卷编号
        private string titleAddress;//题目地址
        private double errorRate;//错误率
        private string answerAddress;//答案地址
        public TitleDetail() { }
        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public int TitleID
        {
            get
            {
                return titleID;
            }

            set
            {
                titleID = value;
            }
        }

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

        public string TitleAddress
        {
            get
            {
                return titleAddress;
            }

            set
            {
                titleAddress = value;
            }
        }

        public double ErrorRate
        {
            get
            {
                return errorRate;
            }

            set
            {
                errorRate = value;
            }
        }

        public string AnswerAddress
        {
            get
            {
                return answerAddress;
            }

            set
            {
                answerAddress = value;
            }
        }
    }
}
