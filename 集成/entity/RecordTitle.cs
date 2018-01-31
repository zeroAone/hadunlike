using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图片合成.Entity
{
    /* 	作者:    Administrator
	*	时间:    2018/1/22 星期一 14:49:15
	*	描述信息：做题记录表
	**/
    class RecordTitle
    {
        private string studentID;//学号
        private int titleID;//题目编号
        private DateTime solvQuestionTime;//做题时间
        private string rightOrWrong;//对错
        private int scoreTitle;//得分
        private string testID;//试卷编号
        private double historyRight;//历史正确率
        private string jpgAddress;//题目图片地址



        //构造函数
        public RecordTitle(string studentID, int titleID, DateTime solvQuestionTime, string rightOrWrong, int scoreTitle, string testID, double historyRight, string jpgAddress)
        {
            this.studentID = studentID;
            this.titleID = titleID;
            this.solvQuestionTime = solvQuestionTime;
            this.rightOrWrong = rightOrWrong;
            this.scoreTitle = scoreTitle;
            this.testID = testID;
            this.historyRight = historyRight;
            this.jpgAddress = jpgAddress;
        }

        public string StudentID
        {
            get
            {
                return studentID;
            }

            set
            {
                studentID = value;
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

        public DateTime SolvQuestionTime
        {
            get
            {
                return solvQuestionTime;
            }

            set
            {
                solvQuestionTime = value;
            }
        }

        public string RightOrWrong
        {
            get
            {
                return rightOrWrong;
            }

            set
            {
                rightOrWrong = value;
            }
        }

        public int ScoreTitle
        {
            get
            {
                return scoreTitle;
            }

            set
            {
                scoreTitle = value;
            }
        }

        public string TestID
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

        public double HistoryRight
        {
            get
            {
                return historyRight;
            }

            set
            {
                historyRight = value;
            }
        }

        public string JpgAddress
        {
            get
            {
                return jpgAddress;
            }

            set
            {
                jpgAddress = value;
            }
        }
    }
}
