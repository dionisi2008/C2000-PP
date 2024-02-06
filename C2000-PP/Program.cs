using System.Net.Sockets;
using C2000_PP;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            C2000_PP.C2000_PP u = new C2000_PP.C2000_PP("10.1.2.20", 40005, 1, 9600);
            u.Функции_Запроса_И_Устоновки_Состояния.Команда_Устоновки_Состояния_Раздела(3, C2000_PP_Info.States_Zone.Взятие_ШС);

            for (int i = 0; i <= 200; i++)
            {
                //u.Функции_Запроса_И_Устоновки_С52остояния.Команда_Устоновки_Состояния_Раздела(3, C2000_PP_Info.States_Zone.Взятие_ШС);
                Console.WriteLine(u.Функции_Запроса_И_Устоновки_Состояния.ЗапросСостоянияЗоны(6)[0] + " " + u.Функции_Запроса_И_Устоновки_Состояния.ЗапросСостоянияЗоны(6)[1]);
                
                
            }










        }
    }
}