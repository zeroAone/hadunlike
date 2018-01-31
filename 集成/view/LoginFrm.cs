using CCWin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 集成.entity;

namespace 集成.view
{
    public partial class LoginFrm : CCSkinMain
    {
        List<User> userList = new List<User>();
        public LoginFrm()
        {
            InitializeComponent();
        }
        private void login_Load(object sender, EventArgs e)
        {
            getData();
        }
        private void loginButtn_Click(object sender, EventArgs e)
        {
            string a = txtId.Text.ToString().Trim();
            string b = txtPwd.Text.ToString().Trim();

            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].getUser() == a && userList[i].getPasswd() == b)
                {
                    BaseFrm newForm = new BaseFrm();
                    this.Visible = false;
                    newForm.Visible = true;
                }

            }
        }
        public void getData()
        {

            MySqlConnection myconn = null;
            MySqlCommand mycom = null;
            MySqlDataAdapter myrec = null;
            myconn = new MySqlConnection("Database=hadunlike;Server='localhost';User Id='root';Password='root';charset='utf8';pooling=true");
            try
            {
                myconn.Open();
                mycom = myconn.CreateCommand();
                string sql = string.Format("SELECT * FROM 系统用户表 ");
                mycom.CommandText = sql;
                mycom.CommandType = CommandType.Text;
                MySqlDataReader sdr = mycom.ExecuteReader();

                while (sdr.Read())
                {
                    User u = new User();
                    u.setUser(sdr[0].ToString());
                    u.setPasswd(sdr[1].ToString());
                    u.setType(sdr[2].ToString());
                    userList.Add(u);
                }
            }
            catch (Exception) { }
            myconn.Close();
        }

        private void exitButtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
