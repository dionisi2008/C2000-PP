using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace C2000_PP
{
    public class C2000_PP
    {
        public enum States
        {
            Восстановление_сети = 1,
            Авария_сети_220_В = 2,
            Тревога_Проникновения = 3,
            Помеха = 4,
            Отключение_Звука = 5,
            Помеха_Устранена = 6,
            -------------------------------------------------------9
        }
        protected Int16 Max_Relay { get; set; }
        protected Int16 Max_Zone { get; set; }
        protected Int16 Max_Razdels { get; set; }
        protected Int16 Max_State_Zone { get; set; }
        protected Int16 Max_State_Razdel { get; set; }
        protected Int16 Max_Size_Event { get; set; }
        protected Int16 max_event_description_length { get; set; }

        private string IP_address;
        private int UDP_Port;
        private byte AddressOfDevices;
        private int Speed;
        private UdpClient udpClient;
        protected string DevicesType;
        protected Int16 DevicesVersion;

        public C2000_PP(string IP_address, int UDP_Port, byte AddressOfDevices, int Speed)
        {
            this.IP_address = IP_address;
            this.UDP_Port = UDP_Port;
            this.AddressOfDevices = AddressOfDevices;
            this.Speed = Speed;
            Max_Relay = ПолучитьЗапросМаксимальногоКоличестваРеле();
            Max_Zone = ПолучитьМаксимальноеКоличествоЗон();
            Max_Razdels = ЗапросМаксимальногоКоличестваРазделов();
            Max_State_Zone = ЗапросМаксимальногоКоличестваСостоянийЗоны();
            Max_State_Razdel = ЗапросМаксимальногоКоличестваСостоянийРаздела();
            Max_Size_Event = ЗапросМаксимальногоКоличестваСобытий();
            max_event_description_length = ЗапросМаксимальнойДлиныОписанияСобытия();
            Запрос_типа_и_версии_прибора();
        }

        private Int16 ПолучитьЗапросМаксимальногоКоличестваРеле()
        {
            var WriteData = new List<byte> { 0xB4, 0x40, 0, 1 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, WriteData.ToArray()));
            return BitConverter.ToInt16(response[3..^2]);
        }
        private Int16 ПолучитьМаксимальноеКоличествоЗон()
        {
            var writeData = new List<byte> { 0xB4, 0x41, 0, 1 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            return BitConverter.ToInt16(response[3..^2]);
        }

        private Int16 ЗапросМаксимальногоКоличестваРазделов()
        {
            var writeData = new List<byte> { 0xB4, 0x42, 0, 1 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            return BitConverter.ToInt16(response[3..^2]);
        }

        private Int16 ЗапросМаксимальногоКоличестваСостоянийЗоны()
        {
            var writeData = new List<byte> { 0xB4, 0x43, 0, 1 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            return BitConverter.ToInt16(response[3..^2]);
        }

        private Int16 ЗапросМаксимальногоКоличестваСостоянийРаздела()
        {
            var writeData = new List<byte> { 0xB4, 0x44, 0, 1 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            return BitConverter.ToInt16(response[3..^2]);
        }

        private Int16 ЗапросМаксимальногоКоличестваСобытий()
        {
            var writeData = new List<byte> { 0xB4, 0x45, 0, 1 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            return BitConverter.ToInt16(response[3..^2]);
        }

        private Int16 ЗапросМаксимальнойДлиныОписанияСобытия()
        {
            var writeData = new List<byte> { 0xB4, 0x46, 0, 1 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            return BitConverter.ToInt16(response[3..^2]);
        }
        private void Запрос_типа_и_версии_прибора()
        {
            var writeData = new List<byte> { 0xB4, 0x48, 0, 2 };
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            this.DevicesType = "Null";
            if (BitConverter.ToInt16(response[3..^4]) == 36)
            {
                this.DevicesType = "C2000-PP";
            }
            DevicesVersion = BitConverter.ToInt16(response[5..^2]);
        }

        public  UInt16 ЗапросСостоянияЗоны(int Numbe_Zone)
        {

            var writeData = new List<byte>(BitConverter.GetBytes((ushort)(40000 + (Numbe_Zone - 1)))[..^2]);
            writeData.AddRange(new byte[] { 0, 1 });
            var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
            return BitConverter.ToUInt16(response[3..^2]);
        }


        public byte[] SendData(PacketData data)
        {
            try
            {
                using (var udpClient = new UdpClient())
                {
                    udpClient.Connect(IP_address, UDP_Port);
                    udpClient.Send(data.ПолучитьПакетВВидеБайт(), data.ПолучитьПакетВВидеБайт().Length);

                    // Ждем 500 мс
                    System.Threading.Thread.Sleep(500);

                    // Проверяем наличие ответа
                    if (udpClient.Available > 0)
                    {
                        IPEndPoint remoteEndPoint = null;
                        byte[] response = udpClient.Receive(ref remoteEndPoint);
                        return response;
                    }
                    else
                    {
                        Console.WriteLine("No response received.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending data via UDP: " + ex.Message);
            }

            return null;
        }
    }
}