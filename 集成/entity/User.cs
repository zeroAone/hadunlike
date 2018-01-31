using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 集成.entity
{
    /* 	作者:    Administrator
	*	时间:    2018/1/22 星期一 19:59:30
	*	描述信息：
	**/
    class User
    {
        private string user;
        private string passwd;
        private string type;
        public User()
        {

        }
        public User(string user,string passwd)
        {
            this.user = user;
            this.passwd = passwd;
        }
        public void setUser(string user)
        {
            this.user = user;
        }
        public string getUser()
        {
            return user;
        }
        public void setPasswd(string passwd)
        {
            this.passwd = passwd;
        }
        public string getPasswd()
        {
            return passwd;
        }
        public void setType(string type)
        {
            this.type = type;
        }
        public string getType()
        {
            return type;
        }
    }
}
