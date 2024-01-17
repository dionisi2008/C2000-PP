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

            

            byte[] ss = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            System.Console.WriteLine(string.Join('-', ss[2..^2]));

            System.Console.WriteLine(string.Join('-', BitConverter.GetBytes((ushort)(40000 + (745 - 1)))));

            var writeData = new List<byte>(new byte[] { 0xb4, 0x60 });
            System.Console.WriteLine(string.Join('-', BitConverter.ToUInt16(writeData.ToArray().Reverse().ToArray(), 0)));
            Console.WriteLine(string.Join('-', BitConverter.GetBytes((ushort)46176).Reverse().ToArray()));

            byte[] ert = new byte[]{0, 0x20};
            Console.WriteLine(BitConverter.ToUInt16(ert.Reverse().ToArray()));
            
            
            
             


        }
    }
}