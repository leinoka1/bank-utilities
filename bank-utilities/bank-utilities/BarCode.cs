using System;
using System.Collections.Generic;
using System.Text;

namespace Ekoodi.Utilities.Bank
{
    public static class BarCode
    {
        // version 4 is for national cases
        public static string CreateVirtualBarCode4(string iban, string euros, string rf, string dueD)
        {
            double barCodeNumeric;
            string barCode;
            euros = euros.Replace(",", "");
            euros = euros.PadLeft(8);
            euros = euros.Replace(" ", "0");
            rf = rf.PadLeft(20);
            rf = rf.Replace(" ", "0");
            barCode = "105" + "4" + iban.Substring(2) + euros + "000" + rf + dueD;
            //barCodeNumeric = Convert.ToDouble(barCode);
            string barCodeTwin;
            int barCodeTwinN, subSum, sum = 0;
            for (int i = 1; i <= 27; i++)
            {
                barCodeTwin = "";
                barCodeTwinN = 0;
                subSum = 0;
                for (int j = 1; j <= 2; j++)
                {
                    barCodeTwin = barCodeTwin + barCode.Substring((i * 2 + j), 1);
                    barCodeTwinN = Convert.ToInt32(barCodeTwin);
                }
                subSum = i * barCodeTwinN;
                Console.Write(" {0:D2}", i);
                Console.Write(" {0:D2}",barCodeTwinN);
                Console.WriteLine(" {0:D5}",subSum);
                sum = sum + subSum;
            }
            sum = sum + 105;
          
            Console.WriteLine(barCode);
            Console.WriteLine(sum);
            Console.WriteLine(sum % 103);
            Console.ReadKey();
            return barCode;
        }

        // version 5 is for international cases
        public static string CreateVirtualBarCode5(string iban, string euros, string rf, string dueD)
        {
            string barCode;
            euros = euros.Replace(",", "");
            euros = euros.PadLeft(8);
            euros = euros.Replace(" ", "0");
            barCode = "105" + "5" + iban.Substring(2) + euros + rf + " " + dueD + "#";
            barCode = iban + euros + rf + dueD;
            return barCode;
        }
    }
}
