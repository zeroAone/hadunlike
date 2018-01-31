using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 集成
{
    class XmlParse
    {
        //private static 

        /// <summary> 
        /// 创建XML文件
        /// </summary> 
        /// <param name="filename"></param> 
        public bool createXmlFile(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(node);
            XmlNode root = xmlDoc.CreateElement("testpaper");
            xmlDoc.AppendChild(root);
            try
            {
                xmlDoc.Save(filename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("出错信息" + e);
            }
            return false;
        }

        //插入新节点
        public bool insertNode(string filepath, string number, string up, string down)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNode root = xmlDoc.SelectSingleNode("testpaper");//查找<testpaper>
            if (root != null)
            {
                XmlElement xe1 = xmlDoc.CreateElement("title");//创建一个<title>节点

                XmlElement xesub1 = xmlDoc.CreateElement("number");
                xesub1.InnerText = number;//设置文本节点
                xe1.AppendChild(xesub1);//添加到<title>节点中
                XmlElement xesub2 = xmlDoc.CreateElement("up");
                xesub2.InnerText = up;
                xe1.AppendChild(xesub2);
                XmlElement xesub3 = xmlDoc.CreateElement("down");
                xesub3.InnerText = down;
                xe1.AppendChild(xesub3);

                root.AppendChild(xe1);//添加到<testpaper>节点中
                try
                {
                    xmlDoc.Save(filepath);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("出错信息" + ex);
                }
            }
            return false;
        }
        /// <summary>
        /// 读取xml中的所有信息:
        /// 包括题目编号、上限、下限
        /// </summary>
        public ArrayList readAll(string filepath)
        {
            ArrayList list = new ArrayList();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("testpaper").ChildNodes;//testpaper

            foreach (XmlNode xn in nodeList)//遍历所有的title节点
            {
                Title title = new Title();
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型
                XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点，即编号，上限，下限

                foreach (XmlNode xn1 in nls)//遍历
                {
                    XmlElement xe2 = (XmlElement)xn1;//转换类型
                    if (xe2.Name == "number")//如果找到题号
                    {
                        title.Number = xe2.InnerText;
                    }
                    if (xe2.Name == "up")//如果找到上限
                    {
                        title.Up = xe2.InnerText;
                    }
                    if (xe2.Name == "down")//如果找到下限
                    {
                        title.Down = xe2.InnerText;
                    }
                }
                list.Add(title);
            }

            ///尝试遍历所有节点
            foreach (Title t in list)
            {
                Console.WriteLine("number:" + t.Number + "  up:" + t.Up + "  down:" + t.Down);
            }
            return list;
        }
    }
}
