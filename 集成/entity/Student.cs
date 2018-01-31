using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图片合成.Entity
{
    /* 	作者:    Administrator
	*	时间:    2018/1/22 星期一 14:21:29
	*	描述信息：学生信息表
	**/
    public class Student
    {
        private int ID;//ID
        private int stuID;//学号
        private string stuName;//姓名
        public Student()
        {

        }

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

        public int StuID
        {
            get
            {
                return stuID;
            }

            set
            {
                stuID = value;
            }
        }

        public string StuName
        {
            get
            {
                return stuName;
            }

            set
            {
                stuName = value;
            }
        }
    }
}
