using System;
using System.Collections.Generic;
using System.Text;

namespace Ekoodi.Utilities.Bank
{
    public static class BbanValidator
    {
        public static string ReadAccountNumber(string input, int output)
        {
            char bankGroupNumber;
            while (input.Length >= 14 || input.Length < 9)
            {
                Exception ex = new FormatException("Too long or short Account Number");
                throw ex;
            }
            // Parse bank company
            int i = 0;
            string plainOriginalAccountNumber = "";
            foreach (Char c in input)
            {
                if (c != '-')
                {
                    i++;
                    if (Char.IsNumber(c) == true)
                        plainOriginalAccountNumber = plainOriginalAccountNumber + c;
                    else
                    {
                        Exception ex = new FormatException("Account Number contains invalid charcter(s), only numeric or minus sign is valid input!");
                        throw ex;
                    }
                }
            }
            bankGroupNumber = plainOriginalAccountNumber[plainOriginalAccountNumber.Length - i];
            // Console.WriteLine(bankGroupNumber);
            string firstPartOfOriginalAccountNumber = "";
            string secondPartOfOriginalAccountNumber = "";
            string fullAccountNumber = "";
            string zeroString = "";
            if (bankGroupNumber == '4' || bankGroupNumber == '5')
            {
                Console.WriteLine(" Seven Zero add");
                for (int j = 0; j < 7; j++)
                {
                    firstPartOfOriginalAccountNumber = firstPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - (i - j)];
                }
                // Console.WriteLine(firstPartOfOriginalAccountNumber);
                for (int j = 8; j < (i+1); j++)
                {
                    secondPartOfOriginalAccountNumber = secondPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - ((i+1) - j)];
                }
                // Console.WriteLine(secondPartOfOriginalAccountNumber);
                for (int k = 0; k <= (14 - (i+1)); k++)
                {
                    zeroString = zeroString + "0";
                }
                fullAccountNumber = firstPartOfOriginalAccountNumber + zeroString + secondPartOfOriginalAccountNumber;
                // Console.WriteLine(fullAccountNumber);
            }
            else
            {
                // Console.WriteLine(" Six Zero add");
                for (int j = 0; j < 6; j++)
                {
                    firstPartOfOriginalAccountNumber = firstPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - (i - j)];
                }
                // Console.WriteLine(firstPartOfOriginalAccountNumber);
                for (int j = 7; j < (i+1); j++)
                {
                    secondPartOfOriginalAccountNumber = secondPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - ((i+1) - j)];
                }
                // Console.WriteLine(secondPartOfOriginalAccountNumber);
                for (int k = 0; k <= (14 - (i+1)); k++)
                {
                    zeroString = zeroString + "0";
                }
                fullAccountNumber = firstPartOfOriginalAccountNumber + zeroString + secondPartOfOriginalAccountNumber;
                // Console.WriteLine(fullAccountNumber);
            }
            // Luhn checking
            int sum = 0, d;
            string num = fullAccountNumber;
            int a = 0;
            for (i = num.Length - 2; i >= 0; i--)
            {
                d = Convert.ToInt32(num.Substring(i, 1));
                if (a % 2 == 0)
                    d = d * 2;
                if (d > 9)
                    d -= 9;
                sum += d;
                a++;
            }
            if ((10 - (sum % 10) == Convert.ToInt32(num.Substring(num.Length - 1))))
            {
                // Console.WriteLine("Checksum is valid");
                return fullAccountNumber;
            }
            else
            {
                Exception ex = new FormatException("Account Number is not valid, checksum is incorrect!");
                throw ex;
            }
            // return fullAccountNumber;
        }
    }
}
