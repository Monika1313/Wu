using System.ComponentModel;
namespace Wu.MathPro
{
    /// <summary>
    /// 数据范围定义
    /// </summary>
    [TypeConverter(typeof(RangeConverter))]
    public class Range
    {
        /// <summary>
        /// 起始值
        /// </summary>
        public double From { get; set; }
        /// <summary>
        /// 终止值
        /// </summary>
        public double To { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public double Max => Math.Max(From, To);
        /// <summary>
        /// 最小值
        /// </summary>
        public double Min => Math.Min(From, To);
        /// <summary>
        /// 差值
        /// </summary>
        public double Distance => Math.Abs(Max - Min);


        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Range(){ }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"{From},{To}";
        }
    }
}
