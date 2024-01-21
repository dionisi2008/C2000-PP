using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using C2000_PP;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Это Альфа версия! Укажи имя хоста!" + '\n');

            string host = Console.ReadLine();
            Console.WriteLine("Отлично, теперь порт!" + '\n');
            int port = System.Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Замечально, теперь нужна скорасть (которая еще не реализована)!" + '\n');
            int speed = System.Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ну и на последок адрес устройства" + '\n');
            byte addres = System.Convert.ToByte(Console.ReadLine());
            C2000_PP.C2000_PP uu = new C2000_PP.C2000_PP(host, port, addres, speed);







        }
    }
}