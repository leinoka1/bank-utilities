using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;
using Newtonsoft.Json;

namespace Ekoodi.Utilities.Bank

{
    public static class IbanValidator
    {
        public static string ReadBbanAccountNumber(string input, string output)
        {
            BigInteger accNum;
            string iban = "";
            string ibanCode = "";
            string ibanCheck = "";
            string outputy = input + "151800";
            BigInteger.TryParse(outputy, out accNum);
            int i = 0;
            while (accNum % 97 != 1)
            {
                accNum = accNum + i;
                i++;
            }
            ibanCode = accNum.ToString();
            ibanCheck = ibanCode.Substring(18);
            iban = "FI" + ibanCheck + (accNum / 1000000).ToString();
            if (accNum % 97 == 1)
                Console.WriteLine("IBAN Checksum is valid");
            else
            {
                Exception ex = new FormatException("Account Number is not valid, IBAN Checksum is incorrect!");
                throw ex;
            }
            // 
            // BIC code 
            //
            string[] bicCodeArray = new String[100];

            var bicCodes = ReadBicCodesFromFile();
            string bankName = "";
            // First sort by first number
            BigInteger firstNumber = (accNum / 10000000000000000000);
            BigInteger firstThreeNumbers = (accNum / 100000000000000000);
            BigInteger firstTwoNumbers = (accNum / 1000000000000000000);
            bool bicCodeFound = false;
            int l = 0;
            if (firstNumber == 4 || firstNumber == 7)
            {
                // Three number group
                for (int j = 0; j < bicCodes.Count; j++)
                {
                    if (bicCodes[j].Id == firstThreeNumbers.ToString())
                    {
                        bankName = bicCodes[j].Name;
                        break;
                    }
                }
            }
            else if (firstNumber == 3)
            // Two number group
            {
                for (int j = 0; j < bicCodes.Count; j++)
                {
                    if (bicCodes[j].Id == firstTwoNumbers.ToString())
                    {
                        bankName = bicCodes[j].Name;
                        break;
                    }
                }
            }
            else
            {
                // One number group
                for (int j = 0; j < bicCodes.Count; j++)
                {
                    if (bicCodes[j].Id == firstNumber.ToString())
                    {
                        bankName = bicCodes[j].Name;
                        bicCodeFound = true;
                        // Console.WriteLine ("BIC: {0}", bankName);
                        break;
                    }
                }
            }
            if (bicCodeFound == false)
            {
                Exception ex = new FormatException("BIC code not defined for (One number group)!");
                throw ex;
            }
            return iban+" BIC "+bankName;
        }
        private static List<BicCode> ReadBicCodesFromFile()
        {
            using (var fs = new FileStream("bic-codes.json", FileMode.Open, FileAccess.Read))
            using (var sr = new System.IO.StreamReader(fs))
            {
                string outx = sr.ReadToEnd();
                var bicCodes = JsonConvert.DeserializeObject<List<BicCode>>(outx);
                return bicCodes;
            }
        }
    }
}
