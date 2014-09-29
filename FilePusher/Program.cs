using System;
using System.Globalization;
using SautDnw;

namespace FilePusher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2) PrintHelp();

            string fileName = args[0];
            uint startAddress = args.Length >= 2 ? UInt32.Parse(args[1], NumberStyles.HexNumber) : 0x20008000;
            Console.WriteLine("Файл: {0}", fileName);
            Console.WriteLine("Адрес: {0:X4}", startAddress);
            Console.WriteLine("Устанавливаем соединение с mini100");
            using (S5Pc100UsbConnection connection = S5Pc100UsbConnection.Establish())
            {
                Console.WriteLine("Передаём файл");
                DnwPackage package = DnwPacker.EnpackFile(fileName, startAddress);
                connection.Write(package.GetBuff());
            }
            Console.WriteLine("Закончили");
            Console.ReadLine();
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