using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Wu.Helper
{
    public class Wu_Image
    {
        /// <summary>
        /// 获取指定路径的图片
        /// </summary>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(string filePath)
        {
            BitmapImage bitImage = new BitmapImage();
            bitImage.BeginInit();
            bitImage.UriSource = new Uri(filePath, UriKind.Absolute);
            bitImage.DecodePixelWidth = 300;
            bitImage.EndInit();
            return bitImage;
        }
    }
}
