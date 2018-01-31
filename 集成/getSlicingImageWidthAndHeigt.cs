using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 集成
{
    class getSlicingImageWidthAndHeigt
    {
        public List<string> imagesPath = new List<string>();//在对pictureBox1图片画线的时候，因为是利用图层的原理在来动态更新线，所以imagesPath用来保存画线的图片的路径
        public List<Image> images = new List<Image>();//在使用Image.FromFile(fileaName)，不断的更新图片会导致内存泄漏，需要将加载的图片释放掉
        public List<ImageHeigt> imagesHeigt = new List<ImageHeigt>();//将实体存储在List里面，使用实体将信息生成XML文件    在截图类里面读取数据
        public List<string> titles = new List<string>();//对截图题目的编号
        public List<int> startAndEnd = new List<int>();//截图开始的点和结束的点
        public bool modifyImage = false;//是否开始截图的判断
        public ImageHeigt heigt = null;//ImageHeigt实体来 对每一次截图的信息存储
        public int flag = 1;
        public int startHeigt = -1;//记录每一次画线的开始高度
        public int endHeigt = -1;//记录每一次画线的结束高度
        public int count = 1;//
        public int count1 = 1;
        public  Point newPoin;//记录每一次画线的点
        public Image image;//Image对象 用来保存Image.FromFile(fileaName)对象  并且及时的释放，保证使用内存的正常
        string fileaName;//图片的文件名


        //得到图片路径
       public string MyOpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagesPath.Add(ofd.FileName);
                return ofd.FileName;
            }
            else
            {
                return null;
            }
        }

        //撤销刚才画下的线
        public  string cancelDraw() {
            if (imagesPath.Count - 1 >= 0)
            {
                imagesPath.Remove(imagesPath[imagesPath.Count - 1]);
                fileaName = imagesPath[imagesPath.Count - 1];
               
            }
            if (startAndEnd.Count - 1 >= 0)
            {
                startAndEnd.Remove(startAndEnd[startAndEnd.Count - 1]);
            }

            return fileaName;
        }

        public List<ImageHeigt> getImageHeigt()
        {

            return imagesHeigt;

        }


        public void ConfirmCut() {
            heigt = new ImageHeigt();
            heigt.Title = "第" + count1 + "题";
            heigt.StartHeigt = startAndEnd[0];
            heigt.EndHeigt = startAndEnd[1];
            imagesHeigt.Add(heigt);
            MessageBox.Show(heigt.Title + "   " + heigt.StartHeigt.ToString() + "     " + heigt.EndHeigt.ToString());
            count1++;
            heigt = null;
            startAndEnd.Clear();
        }

    }
}
