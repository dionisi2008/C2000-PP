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

            C2000_PP.C2000_PP test = new C2000_PP.C2000_PP("localhost", 9050, 1, 9600);
            
            


        }
        
    }
}