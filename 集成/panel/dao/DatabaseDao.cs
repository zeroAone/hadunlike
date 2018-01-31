using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图片合成.Entity;
using 集成.entity;

namespace 集成.dao
{
    /* 	作者:    Administrator
	*	时间:    2018/1/23 星期二 11:14:41
	*	描述信息：
	**/
    public class DatabaseDao
    {

        //例子
        //public static void Main(String[] args)
        //{
        //    MySqlConnection mysql = getMySqlCon();
        //    查询sql
        //    String sqlSearch = "select 图片地址 from 题目信息表   ";
        //    插入sql
        //    String sqlInsert = "insert into 学生表 values (null,1808,"你好")";
        //    String sqlInsert = "insert into 试卷表 values (null,'哈顿初一魔鬼计算训练比赛-样卷2','H:\哈顿理科\哈顿初一魔鬼计算训练比赛-样卷___3.pdf')";
        //    String sqlInsert = "insert into 题目表 values (null,1,1805,'H:\哈顿理科\精准计算比赛样卷1\题目\哈顿初一魔鬼计算训练比赛 - 样卷1第1题.png',null,null)";
        //    String sqlInsert = "insert into 错题表 values (18,4,1805,'H:\哈顿理科\精准计算比赛样卷1\题目\哈顿初一魔鬼计算训练比赛 - 样卷1第3题.png)";
        //SELECT * from `题目表` ORDER BY 错误率 DESC;

        //    修改sql
        //    String sqlUpdate = "update 学生信息表 set 姓名='李四' where 学号= '1803'";
        //    删除sql
        //    String sqlDel = "delete from 学生信息表 where 学号 = '1802'";
        //    打印SQL语句
        //    Console.WriteLine(sqlDel);
        //    四种语句对象
        //    MySqlCommand mySqlCommand = getSqlCommand(sqlSearch, mysql);
        //    MySqlCommand mySqlCommand = getSqlCommand(sqlInsert, mysql);
        //    MySqlCommand mySqlCommand = getSqlCommand(sqlUpdate, mysql);
        //    MySqlCommand mySqlCommand = getSqlCommand(sqlDel, mysql);
        //    mysql.Open();
        //    getTitleResultset(mySqlCommand);
        //    getInsert(mySqlCommand);
        //    getUpdate(mySqlCommand);
        //    getDel(mySqlCommand);
        //    记得关闭
        //    mysql.Close();
        //    String readLine = Console.ReadLine();
        //}
        private static string ConnectionConfig = "Data Source=192.168.15.105;User Id=root;Password=root;port=3306;database=hadunliketest";
        /// <summary>
        /// 建立mysql数据库链接
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getMySqlCon()
        {
            //String mysqlStr = "Data Source=localhost;User Id=root;Password=root;port=3306;database=hadunlike";
            // String mySqlCon = ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString;
            MySqlConnection mysql = new MySqlConnection(ConnectionConfig);
            return mysql;
        }
        /// <summary>
        /// 建立执行命令语句对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mysql"></param>
        /// <returns></returns>
        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            //  MySqlCommand mySqlCommand = new MySqlCommand(sql);
            // mySqlCommand.Connection = mysql;
            return mySqlCommand;
        }
        //查询题目图片地址 数据
        public static List<string> getPicturePath(MySqlCommand mySqlCommand)
        {
            List<string> pathList = new List<string>();
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {

                        if (reader[0].ToString() != "") pathList.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return pathList;
        }
        //查询做题记录表 数据
        public static void getRecordResultset(MySqlCommand mySqlCommand)
        {
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (reader[0].ToString() != "") Console.Write("学号:" + reader.GetString(0) + " ");
                        else Console.Write("学号:" + null + " ");
                        if (reader[1].ToString() != "") Console.Write("题目编号:" + reader.GetInt16(1) + " ");
                        else Console.Write("题目编号:" + null + " ");
                        if (reader[2].ToString() != "") Console.WriteLine("做题时间:" + reader.GetDateTime(2) + " ");
                        else Console.WriteLine("做题时间:" + null);
                        if (reader[3].ToString() != "") Console.Write("对错:" + reader.GetString(3) + " ");
                        else Console.Write("对错:" + null + " ");
                        if (reader[4].ToString() != "") Console.Write("得分:" + reader.GetInt16(4) + " ");
                        else Console.Write("得分:" + null + " ");
                        if (reader[5].ToString() != "") Console.WriteLine("试卷编号:" + reader.GetString(5) + " ");
                        else Console.WriteLine("试卷编号:" + null);
                        if (reader[6].ToString() != "") Console.WriteLine("历史正确率:" + reader.GetDouble(6) + " ");
                        else Console.WriteLine("历史正确率:" + null);
                        if (reader[7].ToString() != "") Console.WriteLine("已做题目jpg:" + reader.GetString(7) + " ");
                        else Console.WriteLine("已做题目jpg:" + null);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
        }
        //查询题目信息表 数据
        public static List<TitleDetail> getTitleResultset(MySqlCommand mySqlCommand)
        {
            //MySqlCommand mySqlCommand = getSqlCommand(sqlSearch, mysql);
            List<TitleDetail> a = new List<TitleDetail>();


            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        TitleDetail a1 = new TitleDetail();
                        if (reader[0].ToString() != "") a1.ID1 = reader.GetInt16(0);
                        if (reader[1].ToString() != "") a1.TitleID = reader.GetInt16(1);
                        if (reader[2].ToString() != "") a1.TestID = reader.GetInt16(2);
                        if (reader[3].ToString() != "") a1.TitleAddress = reader.GetString(3);
                        if (reader[4].ToString() != "") a1.ErrorRate = reader.GetDouble(4);
                        if (reader[5].ToString() != "") a1.AnswerAddress = reader.GetString(5);
                        a.Add(a1);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();

            }
            return a;
        }
        //查询试卷表 数据
        public static List<Test> getTestResultset(MySqlCommand mySqlCommand)
        {
            List<Test> test = new List<Test>();
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Test t = new Test();
                        if (reader[0].ToString() != "") t.TestID = reader.GetInt16(0);
                        if (reader[1].ToString() != "") t.TestName = reader.GetString(1);
                        if (reader[2].ToString() != "") t.TestAddress = reader.GetString(2);
                        if (reader[3].ToString() != "") t.TestAnswer = reader.GetString(3);
                        test.Add(t);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return test;
        }

        /// <summary>
        /// 查询并获得结果集并遍历
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static List<Student> getStudentList(MySqlCommand mySqlCommand)
        {
            List<Student> student = new List<Student>();
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Student s = new Student();
                        s.ID1 = reader.GetInt16(0);
                        s.StuID = reader.GetInt16(1);
                        s.StuName = reader.GetString(2);
                        student.Add(s);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return student;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getInsert(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("插入数据失败了！" + message);
            }

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getUpdate(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                String message = ex.Message;
                Console.WriteLine("修改数据失败了！" + message);
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getDel(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("删除数据失败了！" + message);
            }
        }
    }
}
