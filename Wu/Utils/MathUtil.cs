using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Utils
{
    public class MathUtil
    {
        /// <summary>
        /// 将输入值标准化为 0~1的值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Normalize1(double value,double min, double max)
        {
            return (value - min) / (max - min);
        }

        /// <summary>
        /// 将输入值去标准化 映射到值
        /// </summary>
        /// <param name="normalize1"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Scale1(double normalize1, double min ,double max)
        {
            return (max - min) * normalize1 + min;
        }


        public static double Normalize_Scale(double value, double n_min,double n_max, double s_min,double s_max)
        {
            return Scale1(Normalize1(value, n_min, n_max), s_min, s_max);
        }



        //计算两点间的距离
        public static double Distance(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            double x11 = (double)x1;
            double x22 = (double)x2;
            double y11 = (double)y1;
            double y22 = (double)y2;
            double distance = Math.Sqrt(Math.Pow((x11 - x22), 2) + Math.Pow((y11 - y22), 2));
            //MessageBox.Show(x11.ToString() + y11.ToString() + x22.ToString() + y22.ToString() + distance.ToString());
            return distance;
        }


        //计算两点间的距离
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            return distance;
        }




        /// <summary>
        /// 输入不定数量的整数求和
        /// </summary>
        /// <param name="vals"></param>
        /// <returns></returns>
        public static int SumVals(params int[] vals)
        {
            int sum = 0;
            foreach(var x in vals)
            {
                sum += x;
            }
            return sum;
        }







        /// <summary>
        /// 角度转换弧度系数
        /// </summary>
        const double D2R = (Math.PI / 180.0);

        ///// <summary>
        ///// 角度转换弧度   极坐标转换笛卡尔坐标
        ///// </summary>
        ///// <param name="angle"></param>
        ///// <param name="radius"></param>
        ///// <returns></returns>
        //public static Point PolarToCartesian(double angle, double radius)
        //{
        //    var rad = angle * D2R;                  //角度乘以系数转换为弧度
        //    var x = radius * Math.Cos(rad);
        //    var y = radius * Math.Sin(rad);
        //    return new Point(x, y);
        //}



        /// <summary>
        /// 线性插值   使用两点式方程
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double LinearInterpolation(double x1, double y1, double x2, double y2, double x)
            => y1 + (y2 - y1) / (x2 - x1) * (x - x1);


        ///// <summary>
        ///// 线性插值
        ///// </summary>
        ///// <param name="p1"></param>
        ///// <param name="p2"></param>
        ///// <param name="x"></param>
        ///// <returns></returns>
        //public static double LinearInterpolation(Point p1, Point p2, double x)
        //    => LinearInterpolation(p1.X, p1.Y, p2.X, p2.Y, x);













        ///// <summary>
        ///// 重力加速度
        ///// </summary>
        //const double g = 9.81;
        ///// <summary>
        ///// 水的密度 1000kg/m3
        ///// </summary>
        //const double rouWater = 1000;
        ///// <summary>
        ///// 计算水泵设备的扬程
        ///// </summary>
        ///// <param name="p1">进口压力</param>
        ///// <param name="p2">出口压力</param>
        ///// <param name="v1">进口流速</param>
        ///// <param name="v2">出口流速</param>
        ///// <param name="z1">进口测压点高度</param>
        ///// <param name="z2">出口测压点高度</param>
        ///// <returns>扬程</returns>
        //public static double PumpLift(double p1,double p2, double v1,double v2,double z1,double z2)
        //{
        //    double h1 = (p2 - p1) / (2 * rouWater);                           //压力差
        //    double h2 = (Math.Pow(v2, 2) - Math.Pow(v1, 2)) / (2 * g);        //动能差
        //    double h3 = z2 - z1;                                              //位能差
        //    return h1 + h2 + h3;                                              
        //}

        ///// <summary>
        ///// 计算水泵设备的扬程
        ///// </summary>
        ///// <param name="p1">进口压力</param>
        ///// <param name="p2">出口压力</param>
        ///// <param name="l1">进口管径</param>
        ///// <param name="l2">出口管径</param>
        ///// <param name="q">流量</param>
        ///// <param name="z1">进口测压点高度</param>
        ///// <param name="z2">出口测压点高度</param>
        ///// <returns>扬程</returns>
        //public static double PumpLift(double p1, double p2, double l1, double l2, double q, double z1, double z2)
        //{
        //    double v1 = q / (Math.PI * Math.Pow(l1, 2));             //进口流速
        //    double v2 = q / (Math.PI * Math.Pow(l2, 2));             //出口流速
        //    return PumpLift(p1, p2, v1, v2, z1, z2);                 
        //}

    }
}
