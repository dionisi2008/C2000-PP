using System;

namespace C2000_PP
{
    public class C2000_PP : C2000_PP_Info
    {
        public C2000_PP_Func Функции;
        public C2000_PP(string IP_address, int UDP_Port, byte AddressOfDevices, int Speed) : base(IP_address, UDP_Port, AddressOfDevices, Speed)
        {

        }
    }
}