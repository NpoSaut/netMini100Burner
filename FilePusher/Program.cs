using System;
using System.Globalization;
using System.IO;
using LibUsbDotNet;
using SautDnw;

namespace FilePusher
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2) PrintHelp();

            string fileName = args[0];
            UInt16 startAddress = UInt16.Parse(args[1], NumberStyles.HexNumber);
            Console.WriteLine("Файл: {0}", fileName);
            Console.WriteLine("Адрес: {0:X4}", startAddress);
            Console.WriteLine("Устанавливаем соединение с mini100");
            using (var connection = S5Pc100UsbConnection.Establish())
            {
                Console.WriteLine("Передаём файл");
                var package = DnwPacker.EnpackFile(fileName, startAddress);
                connection.Write(package.GetBuff());
            }
            Console.WriteLine("Закончили");
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Программа для записи файла в mini100");
            Console.WriteLine("Параметры запуска:");
            Console.WriteLine("    {имя_файла} {стартовый_адрес}");
            Console.WriteLine("    {имя_файла} - путь к файлу, который нужно прошить");
            Console.WriteLine("    {стартовый_адрес} - адрес, с которого нужно начать прошивку (в hex)");
        }
    }
}
