using System;
using System.Linq;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using SautDnw.Exceptions;

namespace SautDnw
{
    public class S5Pc100UsbConnection : IDisposable
    {
        public const int Vid = 0x04e8;
        public const int Pid = 0x1234;

        private IUsbDevice Device { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="T:System.Object"/>.
        /// </summary>
        public S5Pc100UsbConnection(IUsbDevice Device) { this.Device = Device; }

        /// <summary>
        /// Открывает USB-устройство s5pk100
        /// </summary>
        private static IUsbDevice GetDevice()
        {
            var ad = UsbDevice.AllDevices.ToList();
            var deviceReg = UsbDevice.AllDevices.FirstOrDefault(dev => dev.Vid == Vid && dev.Pid == Pid);
            if (deviceReg == null) throw new ApplicationException("Оборудование не наидено");

            var device = deviceReg.Device;
            if (!device.Open()) throw new ApplicationException("Не получилось открыть устройство!");

            var idev = (IUsbDevice)device;
            idev.SetConfiguration(1);
            idev.ClaimInterface(0);

            return idev;
        }

        public static S5Pc100UsbConnection Establish()
        {
            var res = new S5Pc100UsbConnection(GetDevice());
            Console.WriteLine("Подключено к {0}", res.Device.Info);
            return res;
        }

        public void Write(Byte[] Buff)
        {
            Console.WriteLine("Открываем End Point");
            using (var epWriter = Device.OpenEndpointWriter((WriteEndpointID)2))
            {
                Console.Write("Пишем... ");
                int length;
                epWriter.Write(Buff, 1000, out length);
                Console.WriteLine("записали {0} байт из {1}", length, Buff.Length);
                if (length != Buff.Length) throw new UsbTransmitException();
            }
            Console.WriteLine("Закрыли End Point");
        }

        /// <summary>
        /// Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            Device.ReleaseInterface(0);
            Device.Close();
        }
    }
}