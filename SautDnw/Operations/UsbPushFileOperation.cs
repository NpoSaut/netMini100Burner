using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace SautDnw.Operations
{
    /// <summary>
    /// Операция по передаче файла через USB
    /// </summary>
    public class UsbPushFileOperation : IOperation
    {
        /// <summary>
        /// Передаваемый файл
        /// </summary>
        public DnwPackage Package { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public UsbPushFileOperation(DnwPackage Package)
        {
            this.Package = Package;
        }

        public void Execute()
        {
            using (var connection = S5Pc100UsbConnection.Establish())
            {
                connection.Write(Package.GetBuff());
            }
        }
    }
}
