using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace PSTE_Library
{
    public class ImageHelper
    {
        public static void CaptureImage(Image fromImage , Rectangle rect, string toImagePath)
        {
            Bitmap bitmap = new Bitmap(rect.Width,rect.Height);
            //创建作图区域
            Graphics graphic = Graphics.FromImage(bitmap);
            //截取原图相应区域写入作图区
            graphic.DrawImage(fromImage, 0, 0, rect, GraphicsUnit.Pixel);
            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            //保存图片
            saveImage.Save(toImagePath);
            //释放资源   
            saveImage.Dispose();
            graphic.Dispose();
            bitmap.Dispose();

        }

    }
}
