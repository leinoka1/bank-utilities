using System;
using System.Collections.Generic;
using System.Text;

namespace Ekoodi.Utilities.Bank
{
    public static class BbanValidator
    {
        public static string ReadAccountNumber(string input, int output)
        {
            // string userInput;
            // int numericAccountNumber;
            // Console.WriteLine("anna tilinumero 9-14 merkkia");
            // input = Console.ReadLine();
            char bankGroupNumber;
            while (input.Length >= 14 || input.Length < 9)
            {
                Console.WriteLine("merkkipituus {0}", input.Length);
                Exception ex = new FormatException("Too long or short Account Number");
                throw ex;


                // Console.WriteLine("Too long or short Account Number");
                // Console.WriteLine("anna tilinumero uudelleen");
                // userInput = Console.ReadLine();
            }
            // int.TryParse(userInput, out numericAccountNumber);
            // Console.WriteLine("numeric Account Number is: {0}", numericAccountNumber);
            // Parse bank company
            int i = 0;
            string plainOriginalAccountNumber = "";
            foreach (Char c in input)
            {
                i++;
                if (c != '-')
                    plainOriginalAccountNumber = plainOriginalAccountNumber + c;
            }
            bankGroupNumber = plainOriginalAccountNumber[plainOriginalAccountNumber.Length - (i - 1)];
            Console.WriteLine(bankGroupNumber);
            string firstPartOfOriginalAccountNumber = "";
            string secondPartOfOriginalAccountNumber = "";
            string fullAccountNumber = "";
            string zeroString = "";
            if (bankGroupNumber == '4' || bankGroupNumber == '5')
            {
                Console.WriteLine(" Seven Zero add");
                for (int j = 0; j < 7; j++)
                {
                    firstPartOfOriginalAccountNumber = firstPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - (i - 1 - j)];
                }
                Console.WriteLine(firstPartOfOriginalAccountNumber);
                for (int j = 8; j < i; j++)
                {
                    secondPartOfOriginalAccountNumber = secondPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - (i - j)];
                }
                Console.WriteLine(secondPartOfOriginalAccountNumber);
                for (int k = 0; k <= (14 - i); k++)
                {
                    zeroString = zeroString + "0";
                }
                fullAccountNumber = firstPartOfOriginalAccountNumber + zeroString + secondPartOfOriginalAccountNumber;
                Console.WriteLine(fullAccountNumber);
            }
            else
            {
                Console.WriteLine(" Six Zero add");
                for (int j = 0; j < 6; j++)
                {
                    firstPartOfOriginalAccountNumber = firstPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - (i - 1 - j)];
                }
                Console.WriteLine(firstPartOfOriginalAccountNumber);
                for (int j = 7; j < i; j++)
                {
                    secondPartOfOriginalAccountNumber = secondPartOfOriginalAccountNumber + plainOriginalAccountNumber[plainOriginalAccountNumber.Length - (i - j)];
                }
                Console.WriteLine(secondPartOfOriginalAccountNumber);
                for (int k = 0; k <= (14 - i); k++)
                {
                    zeroString = zeroString + "0";
                }
                fullAccountNumber = firstPartOfOriginalAccountNumber + zeroString + secondPartOfOriginalAccountNumber;
                Console.WriteLine(fullAccountNumber);

            }
                return fullAccountNumber;
        }
    }
}
