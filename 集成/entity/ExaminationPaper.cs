using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图片合成.Entity
{
    /* 	作者:    Administrator
	*	时间:    2018/1/22 星期一 14:37:09
	*	描述信息：试卷信息表
	**/
    class ExaminationPaper
    {
        private string testID;//试卷编号
        private string courseName;//科目
        private string docAddress;//doc地址
        private DateTime upTime;//上传时间
        private string testTeacher;//出题老师
        private string analyzeTeacher;//审题老师
        private string answerTeacher;//答案负责老师
        private string testType;//试卷类型
        private string cutTitleMode;//分题模板
                            //构造函数
        public ExaminationPaper(string testID, string courseName, string docAddress, DateTime upTime, string testType, string cutTitleMode)
        {
            this.testID = testID;
            this.courseName = courseName;
            this.docAddress = docAddress;
            this.upTime = upTime;
            this.testType = testType;
            this.cutTitleMode = cutTitleMode;
        }
        //构造函数
        public ExaminationPaper(string testID, string courseName, string docAddress, DateTime upTime, string testTeacher, string analyzeTeacher, string answerTeacher, string testType, string cutTitleMode)
        {
            this.testID = testID;
            this.courseName = courseName;
            this.docAddress = docAddress;
            this.upTime = upTime;
            this.testTeacher = testTeacher;
            this.analyzeTeacher = analyzeTeacher;
            this.answerTeacher = answerTeacher;
            this.testType = testType;
            this.cutTitleMode = cutTitleMode;
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

        public string CourseName
        {
            get
            {
                return courseName;
            }

            set
            {
                courseName = value;
            }
        }

        public string DocAddress
        {
            get
            {
                return docAddress;
            }

            set
            {
                docAddress = value;
            }
        }

        public DateTime UpTime
        {
            get
            {
                return upTime;
            }

            set
            {
                upTime = value;
            }
        }

        public string TestTeacher
        {
            get
            {
                return testTeacher;
            }

            set
            {
                testTeacher = value;
            }
        }

        public string AnalyzeTeacher
        {
            get
            {
                return analyzeTeacher;
            }

            set
            {
                analyzeTeacher = value;
            }
        }

        public string AnswerTeacher
        {
            get
            {
                return answerTeacher;
            }

            set
            {
                answerTeacher = value;
            }
        }

        public string TestType
        {
            get
            {
                return testType;
            }

            set
            {
                testType = value;
            }
        }

        public string CutTitleMode
        {
            get
            {
                return cutTitleMode;
            }

            set
            {
                cutTitleMode = value;
            }
        }
    }
}
