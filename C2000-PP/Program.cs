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
            

            bool[] qwer = new bool[] { true, true, false, false, true, false, false, true, false, true, false, false, false, true, false, true, false };
            byte wert = 0;
            for (int i = 0; i < qwer.Length; i++)
            {
                if (qwer[i])
                {
                    wert |= (byte)(1 << i);
                }
            }

            Console.WriteLine(string.Join('-', qwer));
            Console.WriteLine(wert.ToString());

            cons

        }

    }
}