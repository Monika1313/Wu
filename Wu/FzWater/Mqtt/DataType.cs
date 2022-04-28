using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.FzWater.Mqtt
{
    /// <summary>
    /// 数据的类型
    /// </summary>
    enum DataType : byte
    {
        @bool = 0x00,                       //
        signedChar = 0x01,                  //
        unsignedChar = 0x02,                //
        signedShort = 0x03,                 //
        unsignedShort = 0x04,                //
        signedInt = 0x05,                    //
        unsignedInt = 0x06,                  //
        signedLong = 0x07,                   //
        unsignedLong = 0x08,                 //
        @float = 0x09,                       //
        @double = 0x0A,                      //
        datetime = 0x0B,                     //
        asciiString = 0x0C,                  //
        byteArray = 0x0D                     //
    }
}
