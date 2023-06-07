using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RW.PMS.Utils.Drawing
{
    public static class BitmapHelper
    {
        /// <summary>
        /// 转换成灰度图片
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap ConvertGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    int gray = (int)(c.R * 0.2989 + c.G * 0.5870 + c.B * 0.1140);//灰度模型
                    Color newC = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newC);
                }
            }
            return bmp;
        }

        /// <summary>
        /// 二值化图片,根据阀值，阀值默认为128
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public static Bitmap Binaryzation(Bitmap bmp, int threshold)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    //灰度化的图片，R=G=B
                    bmp.SetPixel(i, j, threshold < (255 - c.B) ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255));
                }
            }
            return bmp;
        }

        public static Bitmap Binaryzation(Bitmap bmp)
        {
            return Binaryzation(bmp, 128);
        }
    }
}
