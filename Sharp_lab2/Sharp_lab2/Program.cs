using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharp_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Registry regist = new Registry();

            // Console.WriteLine(regist);
            Registry regist1 = regist.DeepCopy();
            Console.WriteLine(regist1);// ToString
            Organization unic = new Ministry("Нормальный, приходит вовремя", 3, 100, 1300, 20000);
            Organization unic1 = new Ministry("Нормальный, приходит вовремя", 3, 100, 1300, 20000);
            if (unic.Equals(unic1))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine(" Not Equals");
            }

            Console.WriteLine("\n" + unic.GetHashCode() + " " + unic1.GetHashCode());

            int a = 4;
            int b = 2;
            int c = 2; // int c =0;
            try
            {
                a = b / c;
            }
            catch (DivideByZero e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }
    }
}
