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
            string barCode, dueDyy, dueDmm, dueDdd;
            iban = iban.Replace(" ", "");
            euros = euros.Replace(",", "");
            euros = euros.PadLeft(8);
            euros = euros.Replace(" ", "0");
            rf = rf.PadLeft(20);
            rf = rf.Replace(" ", "0");
            if (dueD.Length != 10)
            {
                     Exception ex = new FormatException("Given Date is not valid, length is not 10 characters!");
                throw ex;
            }
            dueD = dueD.Replace(".", "");
            dueDyy = dueD.Substring(6);
            dueDmm = dueD.Substring(2, 1) + dueD.Substring(3, 1);
            dueDdd = dueD.Substring(0, 1) + dueD.Substring(1, 1);
            dueD = dueDyy + dueDmm + dueDdd;
            barCode = "105" + "4" + iban.Substring(2) + euros + "000" + rf + dueD;
            int sum = 0;
            for (int i = 1; i <= 27; i++)
            {
                string barCodeTwin = "";
                int barCodeTwinN = 0;
                int subSum = 0;
                for (int j = 1; j <= 2; j++)
                {
                    barCodeTwin = barCodeTwin + barCode.Substring((i * 2 + j), 1);
                    barCodeTwinN = Convert.ToInt32(barCodeTwin);
                }
                subSum = i * barCodeTwinN;
                //Console.Write(" {0:D2}", i);
                //Console.Write(" {0:D2}", barCodeTwinN);
                //Console.Write(" {0:D5}", subSum);
                sum = sum + subSum;
                //Console.WriteLine(" = {0}", sum);
            }
            sum = sum + 105;
            barCode = barCode + (sum % 103).ToString();
            return barCode;
        }

        // version 5 is for international cases
        public static string CreateVirtualBarCode5(string iban, string euros, string rf, string dueD)
        {
            string barCode, rfPlain, rfEndPart, dueDyy, dueDmm, dueDdd; 
            iban = iban.Replace(" ", "");
            rf = rf.Replace(" ", "");
            euros = euros.Replace(",", "");
            euros = euros.PadLeft(8);
            euros = euros.Replace(" ", "0");
            if (dueD.Length != 10)
            {
                Exception ex = new FormatException("Given Date is not valid, length is not 10 characters!");
                throw ex;
            }
            dueD = dueD.Replace(".", "");
            dueDyy = dueD.Substring(6);
            dueDmm = dueD.Substring(2, 1) + dueD.Substring(3, 1);
            dueDdd = dueD.Substring(0, 1) + dueD.Substring(1, 1);
            dueD = dueDyy + dueDmm + dueDdd;
            rfPlain = rf.Substring(2);
            rfEndPart = rfPlain.Substring(2);
            rfEndPart = rfEndPart.PadLeft(21);
            rfEndPart = rfEndPart.Replace(" ", "0");
            rf = rf.Substring(2, 1) + rf.Substring(3, 1) + rfEndPart;
            barCode = "105" + "5" + iban.Substring(2) + euros + rf + dueD;
            int sum = 0;
            for (int i = 1; i <= 27; i++)
            {
                string barCodeTwin = "";
                int barCodeTwinN = 0;
                int subSum = 0;
                for (int j = 1; j <= 2; j++)
                {
                    barCodeTwin = barCodeTwin + barCode.Substring((i * 2 + j), 1);
                    barCodeTwinN = Convert.ToInt32(barCodeTwin);
                }
                subSum = i * barCodeTwinN;
                //Console.Write(" {0:D2}", i);
                //Console.Write(" {0:D2}", barCodeTwinN);
                //Console.Write(" {0:D5}", subSum);
                sum = sum + subSum;
                //Console.WriteLine(" = {0}", sum);
            }
            sum = sum + 105;
            barCode = barCode + (sum % 103).ToString();
            return barCode;
        }
    }
}
