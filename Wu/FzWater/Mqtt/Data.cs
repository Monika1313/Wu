using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.FzWater.Mqtt
{
    /// <summary>
    /// 数据帧中的消息体的单个数据
    /// </summary>
    public class Data
    {
        public byte Addr { get; set; }               //设备地址
        public byte Chanel { get; set; }             //通道号
        public byte Tag { get; set; }                //Tag
        public byte Type { get; set; }               //数据类型
        public int DecimalDigits { get; set; }       //小数位数
        public dynamic OriginValue { get; set; }     //原始数值
        public dynamic Value { get; set; }           //值  该值由原始数值 根据数据类型和小数位数进行转换
        public bool IsBatch { get; set; }            //是否批量处理

        public override string ToString() => $"设备地址: {Addr} 通道号: {Chanel} Tag: {Tag.ToString("x").PadLeft(2, '0')}  {(Tag)Tag} 值: {Value} "; /*数据类型:{(DataType)Type}; 小数位:{DecimalDigits}; */
    }
}
