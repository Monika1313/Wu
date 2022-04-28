using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wu.Utils;

namespace Wu.FzWater.Mqtt
{
    /// <summary>
    /// Mqtt数据帧  
    /// 包含①帧头 ②消息体 ③帧尾
    /// </summary>
    public class DataFrame
    {
        private DataFrame() { }

        /// <summary>
        /// 使用接收的字节数组初始化
        /// 初始化前将对消息进行Crc校验,若校验失败则CrcChecked为false,且不会初始化数据帧
        /// </summary>
        /// <param name="frame"></param>
        public DataFrame(byte[] frame)
        {
            if (frame == null || frame.Length <= 29) return;
            FrameHeadSynchronizationSymbol = BitConverter.ToString(frame, 0, 2).Replace("-", "");       //帧头同步标志   起始0 2字节
            //帧尾 3Byte
            CrcCheckCode = frame[frame.Length - 3];                                     //Crc校验码
            FrameTailSynchronizationSymbol = BitConverter.ToString(frame, frame.Length - 2, 2).Replace("-", "");            //帧尾同步标志
            //if (!CrcCheck(frame) || FrameHeadSynchronizationSymbol.ToUpper() != "AAFE" || FrameTailSynchronizationSymbol.ToUpper() != "DDEE") return;            //校验失败
            if(CrcCheck(frame)) CrcChecked = true;                          //校验成功

            //帧头 18Byte
            Version = BitConverter.ToString(frame, 2, 1).Replace("-", "");                              //版本号         起始2 1字节
            Length = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 3));                     //帧总长度       起始3 2字节
            IndustryCatagory = frame[5];                                                                    //行业分类编号   起始5 1字节
            Supplier = frame[6];                                                                            //行业分类编号   起始6 1字节
            DtuIp = IPAddress.Parse(IPAddress.NetworkToHostOrder(BitConverter.ToInt32(frame, 7)).ToString()).ToString();    //DtuIP 起始7 4字节
            Cmd = frame[11];                                                                                  //命令码 起始11 1字节
            EquipmentDateTime = new DateTime(frame[12] + 2000, frame[13], frame[14], frame[15], frame[16], frame[17]);       //设备时间  年月日时分秒 起始12 6字节 
            if (Cmd == 0x04) return;             //0x04为心跳包

            #region 消息体
            int msgLength = Length - 21;                 //消息体长度
            int p = 18;                                 //指针 初始指向消息体开头
            int mbe = Length - 3;                       //消息体末尾
            for (; p < mbe;)
            {
                //单个消息体数据
                Data data = new Data
                {
                    Addr = frame[p++],
                    Chanel = frame[p++],
                    Tag = frame[p++],
                    Type = (byte)(frame[p] >> 4),
                    DecimalDigits = frame[p++] & 0x07
                };
                //根据数据类型赋值
                switch (data.Type)
                {
                    case (byte)DataType.@bool:
                        data.OriginValue = frame[p++];
                        data.Value = data.OriginValue == 0x01 ? true : false;
                        break;
                    case (byte)DataType.signedChar:
                        data.OriginValue = frame[p++];
                        data.Value = (int)data.OriginValue;
                        break;
                    case (byte)DataType.unsignedChar:
                        data.OriginValue = frame[p++];
                        data.Value = (int)data.OriginValue;
                        break;
                    case (byte)DataType.signedShort:
                        data.OriginValue = ConvertUtil.GetInt16FromBigEndianBytes(frame, p);
                        data.Value = data.OriginValue * Math.Pow(0.1, data.DecimalDigits);
                        p += 2;
                        break;
                    case (byte)DataType.unsignedShort:
                        data.OriginValue = ConvertUtil.GetUInt16FromBigEndianBytes(frame, p);
                        data.Value = data.OriginValue * Math.Pow(0.1, data.DecimalDigits);
                        p += 2;
                        break;
                    case (byte)DataType.signedInt:
                        data.OriginValue = ConvertUtil.GetIntFromBigEndianBytes(frame, p);
                        data.Value = data.OriginValue * Math.Pow(0.1, data.DecimalDigits);
                        p += 4;
                        break;
                    case (byte)DataType.unsignedInt:
                        data.OriginValue = ConvertUtil.GetUIntFromBigEndianBytes(frame, p);
                        data.Value = data.OriginValue * Math.Pow(0.1, data.DecimalDigits);
                        p += 4;
                        break;
                    case (byte)DataType.signedLong:
                        data.OriginValue = ConvertUtil.GetUInt64FromBigEndianBytes(frame, p);
                        data.Value = data.OriginValue * Math.Pow(0.1, data.DecimalDigits);
                        p += 8;
                        break;
                    case (byte)DataType.unsignedLong:
                        data.OriginValue = ConvertUtil.GetUInt64FromBigEndianBytes(frame, p);
                        data.Value = data.OriginValue * Math.Pow(0.1, data.DecimalDigits);
                        p += 8;
                        break;
                    case (byte)DataType.@float:
                        data.OriginValue = data.Value = ConvertUtil.GetFloatFromBigEndianBytes(frame, p);
                        p += 4;
                        break;
                    case (byte)DataType.@double:
                        data.OriginValue = data.Value = ConvertUtil.GetDouble(frame, p);
                        p += 8;
                        break;
                        //case (byte)DataType.asciiString:
                        //case (byte)DataType.bytearray:
                }
                MessageBody.Add(data);        //将数据添加进消息体
            }
            #endregion
        }



        #region 属性
        public bool CrcChecked { get; set; } = false;
        #region 帧头部分
        public string FrameHeadSynchronizationSymbol { get; set; }//帧头同步标志 
        public string Version { get; set; }            //协议版本号
        public int Length { get; set; }           //帧总长度   不包含帧头和帧尾
        public byte IndustryCatagory { get; set; }     //行业分类编号
        public byte Supplier { get; set; }             //供应商
        public string DtuIp { get; set; }              //DtuIp
        public byte Cmd { get; set; }                  //命令码
        public DateTime EquipmentDateTime { get; set; }    //设备时间 
        #endregion

        #region 帧尾部分
        public byte CrcCheckCode { get; set; }                                //Crc校验码
        public string FrameTailSynchronizationSymbol { get; set; }           //帧尾同步标志
        #endregion

        public List<Data> MessageBody { get; set; } = new List<Data>();                           //消息体

        public DateTime ReceiveTime { get; set; } = DateTime.Now;
        #endregion



        /// <summary>
        /// 对数据进行Crc校验
        /// </summary>
        /// <returns></returns>
        public bool CrcCheck(byte[] frame)
        {
            //对数据帧进行Crc校验
            byte? x = Crc.Crc8Maxim(frame.Take(frame.Length - 3).ToArray());
            return x == frame[frame.Length - 3];
        }


        /// <summary>
        /// 该功能未完成
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            //if (obj == this) return true;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string str = $"协议版本:{Version} 分类:{IndustryCatagory} DtuIp:{DtuIp} Cmd:{Cmd} 设备时间:{EquipmentDateTime}";
            foreach (var item in MessageBody)
            {
                str += "\n" + item.ToString();
            }
            return str; 
        }
    }
}
