using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SautDnw;
using SautDnw.Operations;
using SautDnw.Phases;

namespace cMiniBurner
{
    class Program
    {
        static void Main(string[] args)
        {
            var Phases =
                new List<IPhase>
                {
                    new OperationListPhase(
                        new UsbPushFileOperation(
                            DnwPacker.EnpackBuffer(SautDnw.Properties.Resources.USB_Installer_DDR2, 0x27e00000)),
                        new WaitOperation(TimeSpan.FromMilliseconds(5000))),

                    new OperationListPhase(
                        new UsbPushFileOperation(
                            DnwPacker.EnpackBuffer(SautDnw.Properties.Resources.u_boot_DDR2, 0x27e00000)),
                        new WaitOperation(TimeSpan.FromMilliseconds(1000)))
                };

            foreach (var ph in Phases)
            {
                ph.Execute();
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Мы здесь закончили");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
