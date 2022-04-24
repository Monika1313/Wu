using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wu.Helper
{
    /// <summary>
    /// 福州自来水公司
    /// 远传数据解析
    /// </summary>
    public class Wu_FzWater
    {
        /// <summary>
        /// Mqtt接收的数据解析
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>帧头解析 [0]帧头同步标志  [1]版本号 [2]帧总长度 [3]行业分类编号 [4]供应商编号 [5]DtuIP [6]命令码 [7]年月日时分秒</returns>
        public static ArrayList Analyse(byte[] msg)
        {
            //增加crc校验 验证数据



            //帧头长度
            int fhLength = 18;
            //帧尾长度
            int ftLength = 3;

            #region 帧头 18字节 
            //帧头解析 [0]帧头同步标志  [1]版本号 [2]帧总长度 [3]行业分类编号 [4]供应商编号 [5]DtuIP [6]命令码 [7]年月日时分秒
            ArrayList fhArrayList = new ArrayList();

            //帧头同步标志 起始0 2字节
            string fHSynchronizationSymbol = BitConverter.ToString(msg, 0, 2).Replace("-", "");
            fhArrayList.Add(fHSynchronizationSymbol);

            //版本号 起始2 1字节
            string version = BitConverter.ToString(msg, 2, 1).Replace("-", "");
            fhArrayList.Add(version);

            //帧总长度 起始3 2字节
            int frameLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(msg, 3));
            fhArrayList.Add(frameLength);

            //行业分类编号 起始5 1字节
            fhArrayList.Add(msg[5]);

            //供应商编号 起始6 1字节
            fhArrayList.Add(msg[6]);

            //DtuIP 起始7 4字节
            string dtuIp = IPAddress.Parse(IPAddress.NetworkToHostOrder(BitConverter.ToInt32(msg, 7)).ToString()).ToString();
            //string dtuIp2 = BitConverter.ToUInt16(msg, 7) + "." + BitConverter.ToUInt16(msg, 8) + "." + BitConverter.ToUInt16(msg, 9) + "." + BitConverter.ToUInt16(msg, 10);
            fhArrayList.Add(dtuIp);

            //命令码 起始11 1字节
            fhArrayList.Add(msg[7]);
            //年月日时分秒 起始12 6字节 
            DateTime dateTime = new DateTime(msg[12] + 2000, msg[13], msg[14], msg[15], msg[16], msg[17]);
            fhArrayList.Add(dateTime);
            //fhArrayList.Add(msg[7]);
            #endregion


            #region 消息体
            //消息体长度
            int msgLength = frameLength - fhLength - ftLength;
            //消息体数据
            //List<int[]> msgBody = new List<int[]>();
            ArrayList mbArrayList = new ArrayList();
            //List<ArrayList> msgBodyData = new List<ArrayList>();

          
            //指针 初始指向消息体开头
            int p = fhLength;
            //消息体末尾
            int mbe = frameLength - ftLength;

            for (; p < mbe;)
            {
                //设备地址 通道号 TAG 类型 小数位数
                //单个消息体数据
                ArrayList mbd = new ArrayList();

                //mbd[0]设备地址 mbd[1]通道号 mbd[2]TAG
                for (int i = 0; i<=2; i++)
                {
                    mbd.Add((int)msg[p]);
                    p++;
                }
                //mbd[3]数据类型 
                mbd.Add((int)(msg[p] >> 4));
                //mbd[4]小数位数
                mbd.Add((int)(msg[p] & 0x07));
                p++;
                //mbd[5]数据值 根据数据类型取值   取值均取整型,再根据小数位换算
                switch ((int)mbd[3])
                {
                    case 2:
                        //char 1字节
                        mbd.Add((int)msg[p] * Math.Pow(0.1,(int)mbd[4]));
                        p += 1;
                        break;
                    case 3:
                        //short 2字节
                        mbd.Add(IPAddress.NetworkToHostOrder(BitConverter.ToInt16(msg, p)) * Math.Pow(0.1, (int)mbd[4]));
                        p += 2;
                        break;
                    case 4:
                        //usigned short 2字节
                        //var xxxx = BitConverter.ToUInt16(msg, p);
                        mbd.Add(IPAddress.NetworkToHostOrder(BitConverter.ToInt16(msg, p)) * Math.Pow(0.1, (int)mbd[4]));
                        p += 2;
                        break;
                    case 6:
                        //uint 4字节
                        mbd.Add(IPAddress.NetworkToHostOrder(BitConverter.ToInt32(msg, p)) * Math.Pow(0.1, (int)mbd[4]));
                        p += 4;
                        break;
                }
                //
                mbArrayList.Add(mbd);
            }
            #endregion


            


            #region 帧尾
            ArrayList ftArrayList = new ArrayList();

            //crc校验码
            byte crcCode = msg[msg.Length - 3];
            ftArrayList.Add(crcCode);
            //帧尾同步标志
            string ftSynchronizationSymbol = BitConverter.ToString(msg, msg.Length-2, 2).Replace("-", "");
            ftArrayList.Add(ftSynchronizationSymbol);
            #endregion



            //数据解析后返回解析值
            ArrayList result = new ArrayList
            {
                //帧头
                fhArrayList,
                //消息体
                mbArrayList,
                //帧尾
                ftArrayList
            };
            return result;
        }
    }
}
