using System;
using System.Collections.Generic;
using System.Text;

namespace Ekoodi.Utilities.Bank
{
    public static class National_refernce_number
    {
        public static string NationalRefNumberCheck(string input, string output)
        {
            int sum = 0, d;
            string num = input;
            int a = 1;
            if (num.Length < 4 || num.Length > 20)
            {
                Exception ex = new FormatException("National Reference Number is too long or short");
                throw ex;
            }
            for (int i = num.Length - 2; i >= 0; i--)
            {
                d = Convert.ToInt32(num.Substring(i, 1));
                Console.Write(d);
                if (a % 2 == 0)
                {
                    d = d * 3;
                    Console.WriteLine(" {0}", d);
                }
                else if (a % 3 == 0)
                {
                    d = d;
                    Console.WriteLine(" {0}", d);
                }
                else
                {
                    d = d * 7;
                    Console.WriteLine(" {0}", d);
                }
                if (a == 3)
                    a = 0;
                sum += d;
                a++;
            }
            Console.WriteLine("tulojen summa on {0}", sum);
            Console.ReadKey();
            if ((10 - (sum % 10) == Convert.ToInt32(num.Substring(num.Length - 1))))
            {
                return input;
            }
            else
            {
                Exception ex = new FormatException("National Réference Number is not valid, checksum is incorrect!");
                throw ex;
            }
            return input;
        }
    }
}



