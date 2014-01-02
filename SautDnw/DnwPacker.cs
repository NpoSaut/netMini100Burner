using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SautDnw
{
    public static class DnwPacker
    {
        public static DnwPackage EnpackFile(String FirmwareFileName, UInt32 StartAddress)
        {
            return EnpackFile(new FileInfo(FirmwareFileName), StartAddress);
        }

        public static DnwPackage EnpackFile(FileInfo FirmwareFile, UInt32 StartAddress)
        {
            var res = new DnwPackage()
            {
                Address = StartAddress,
                Data = new byte[FirmwareFile.Length]
            };
            using (var firmwareFileStream = FirmwareFile.OpenRead())
            {
                firmwareFileStream.Read(res.Data, 0, (int)firmwareFileStream.Length);
            }
            return res;
        }

        public static DnwPackage EnpackBuffer(Byte[] Buff, UInt32 StartAddress)
        {
            return new DnwPackage
            {
                Address = StartAddress,
                Data = Buff
            };
        }
    }
}
