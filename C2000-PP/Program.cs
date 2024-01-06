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



            // System.Console.WriteLine(string.Join('_', args[1..]) + " = " + args[0] +',');
            // //Чтение_значений_из_нескольких_регистров_флагов = 0x01,
            // Console.WriteLine("Hello World!");
            // ushort dd = 40128;
            // byte[] w = BitConverter.GetBytes(dd);
            // dd = BitConverter.ToUInt16(w);
            // Console.WriteLine(dd);

            //9CBB


            List<string> s = new List<string>(File.ReadAllLines(@"C:\Users\deniska\Desktop\PP\C2000-PP\C2000-PP\Events.txt"));

            for (int shag = 0; shag <= s.Count - 1; shag++)
            {

                s[shag] = s[shag].Split('|')[1].Replace(' ', '_').Replace('-', '_') + " = " + s[shag].Split('|')[0] + ',';
            }
            File.WriteAllLines(@"C:\Users\deniska\Desktop\PP\C2000-PP\C2000-PP\Events1.txt", s.ToArray());
        }
    }
}