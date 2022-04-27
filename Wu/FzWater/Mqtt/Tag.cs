using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.FzWater.Mqtt
{
    /// <summary>
    /// 数据标签的含义
    /// </summary>
    public enum Tag : byte
    {
        TLV版本 = 0x00,
        外设掉线警告 = 0x01,
        设备心跳命令 = 0x02,

        水源故障 = 0x09,
        PH值 = 0x17,
        浊度 = 0x18,
        余氯 = 0x19,
        水位高度 = 0x1A,
        蓄水池进水口压力 = 0x1B,
        蓄水池出水口压力 = 0x1C,
        管道流速 = 0x1D,
        管道累计流量 = 0x1E,

        环境温度 = 0x1F,
        环境湿度 = 0x20,
        环境噪音 = 0x21,
        环境烟火感应 = 0x22,
        环境积水状态 = 0x23,
        门禁状态 = 0x24,

        A相温度 = 0x25,
        B相温度 = 0x26,
        C相温度 = 0x27,
        A相电流 = 0x28,
        B相电流 = 0x29,
        C相电流 = 0x2A,
        CT = 0x2B,
        PT = 0x2C,
        频率 = 0x2D,
        总有功功率 = 0x2E,
        总无功功率 = 0x2F,
        功率因数总和 = 0x30,
        有功电度总和 = 0x31,
        无功电度总和 = 0x32,

        水表流量读数 = 0x33,
        水表压力 = 0x34,
        泵运行状态 = 0x35,
        泵电压值Ua = 0x36,
        泵电流值Ia = 0x37,
        泵运行总有功功率 = 0x38,
        泵运行频率 = 0x39,
        泵工作温度 = 0x3A,
        泵振动幅度 = 0x3B,
        泵运行时间 = 0x3C,
        泵谁流速 = 0x3D,
        累积流量 = 0x3E,
        泵进口压力 = 0x3F,
        泵出口压力 = 0x40,
        故障次数 = 0x41,
        泵设定频率 = 0x42,
        泵设定压力 = 0x43,
        泵电压值Ub = 0x44,
        泵电压值Uc = 0x45,
        泵电流值Ib = 0x46,
        泵电流值Ic = 0x47,
        泵运行总无功功率 = 0x48,
        泵运行总有功电能 = 0x49,
        泵运行总无功电能 = 0x4A,
        泵总有功因数 = 0x4B,
        水质电导率 = 0x4C,
        蓄水池管道设定压力 = 0x4D,
        水质温度 = 0x4E,
        蓄水池门状态 = 0x4F
    }
}
