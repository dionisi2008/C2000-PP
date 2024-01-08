using System;
using C2000_PP;

public class Func_Состояния : C2000_PP_Info
{
    public Func_Состояния()
    {

    }


    public bool[] Запрос_состояния_группы_реле(int Start_Index_Releay, byte Count_Releay)
    {
        var writeData = new List<byte>(BitConverter.GetBytes((ushort)(10000 + (Start_Index_Releay - 1)))[..^2]);
        writeData.Add(0);
        writeData.Add(Count_Releay);
        var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
        List<bool> tmp2 = new List<bool>();
        for (int shag = 0; shag <= response.Length - 3; shag++)
        {
            string tmp3 = Convert.ToString(response[shag]).PadLeft(8, '0');
            for (int shag2 = 0; shag2 <= 8; shag2++)
            {
                if (tmp3[shag2] == '1')
                {
                    tmp2.Add(true);
                }
                else
                {
                    tmp2.Add(false);
                }
            }
        }

        return tmp2.ToArray();
    }

    public States ЗапросСостоянияЗоны(int Numbe_Zone)
    {
        var writeData = new List<byte>(BitConverter.GetBytes((ushort)(40000 + (Numbe_Zone - 1)))[..^2]);
        writeData.AddRange(new byte[] { 0, 1 });
        var response = SendData(new PacketData(AddressOfDevices, ModbusFunctionCode.Чтение_значений_из_нескольких_регистров_хранения, writeData.ToArray()));
        return (States)BitConverter.ToUInt16(response[3..^2]);
    }

}



