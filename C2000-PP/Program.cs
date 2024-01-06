using System;
using System.Runtime.InteropServices;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            
            System.Console.WriteLine(string.Join('_', args[1..]) + " = " + args[0] +',');
            //Чтение_значений_из_нескольких_регистров_флагов = 0x01,
            Console.WriteLine("Hello World!");
            ushort dd = 40128;
            byte[] w = BitConverter.GetBytes(dd);
            dd = BitConverter.ToUInt16(w);
            Console.WriteLine(dd);

            //9CBB
        }
    }
}