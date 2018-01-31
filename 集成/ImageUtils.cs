using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace 集成
{
    class ImageUtils
    {
        /// <summary>
        /// 截取图片方法
        /// </summary>
        /// <param name="url">图片地址</param>
        /// <param name="beginX">开始位置-X</param>
        /// <param name="beginY">开始位置-Y</param>
        /// <param name="getX">截取宽度</param>
        /// <param name="getY">截取长度</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="savePath">保存路径</param>
        public static string cutImage(string url, int beginX, int beginY, int getX, int getY, string fileName, string savePath)
        {
            Bitmap bitmap = new Bitmap(url);//原图
            if (((beginX + getX) <= bitmap.Width) && ((beginY + getY) <= bitmap.Height))
            {
                Bitmap destBitmap = new Bitmap(getX, getY);//目标图
                Rectangle destRect = new Rectangle(0, 0, getX, getY);//矩形容器
                Rectangle srcRect = new Rectangle(beginX, beginY, getX, getY);

                Graphics graphics = Graphics.FromImage(destBitmap);
                graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);


                destBitmap.Save(savePath + "//" + fileName + ".png");
                return savePath + "\\" + fileName.Split('.')[0] + ".png";
            }
            else
            {
                return "截取范围超出图片范围";
            }
        }
    }
}
