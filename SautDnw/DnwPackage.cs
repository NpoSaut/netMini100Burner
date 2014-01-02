using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SautDnw
{
    /// <summary>
    /// Пакет для отправки на mini100
    /// </summary>
    public class DnwPackage
    {
        /// <summary>Начальный адрес</summary>
        public UInt32 Address { get; set; }
        /// <summary>Данные</summary>
        public Byte[] Data { get; set; }
        /// <summary>Контрольная сумма</summary>
        public UInt16 Checksum
        {
            get { return Data.Aggregate((UInt16)0, (b, s) => (UInt16)(s + b)); }
        }

        private int TotalLength { get { return Data.Length + 10; } }

        /// <summary>Возвращает USB-буффер, который надо отправить</summary>
        public Byte[] GetBuff()
        {
            var ms = new MemoryStream(Data.Length + 10);
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write((UInt32)Address);
                writer.Write((UInt32)TotalLength);
                writer.Write(Data);
                writer.Write((UInt16)Checksum);
            }
            return ms.ToArray();
        }
    }
}
