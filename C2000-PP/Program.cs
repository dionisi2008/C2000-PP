using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            byte b = 2; // Пример байта

            string bitString = Convert.ToString(b, 2).PadLeft(8, '0');
            Console.WriteLine(bitString);
            System.Console.WriteLine(Convert.ToString(b, 2));



        }
    }
}