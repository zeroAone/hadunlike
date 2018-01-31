using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图片合成.Entity
{
    /* 	作者:    Administrator
	*	时间:    2018/1/22 星期一 14:44:51
	*	描述信息：学生成绩表
	**/
    class StudentScore
    {
        private string studentID;//学号
        private int score;//成绩
        private DateTime testTime;//考试时间
        private string testAddress;//考试地点
        private string testID;//试卷编号

        //构造函数
        public StudentScore(string studentID, int score, string testID)
        {
            this.studentID = studentID;
            this.score = score;
            this.testID = testID;
        }

        //构造函数
        public StudentScore(string studentID, int score, DateTime testTime, string testAddress, string testID)
        {
            this.studentID = studentID;
            this.score = score;
            this.testTime = testTime;
            this.testAddress = testAddress;
            this.testID = testID;
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

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public DateTime TestTime
        {
            get
            {
                return testTime;
            }

            set
            {
                testTime = value;
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
    }
}
