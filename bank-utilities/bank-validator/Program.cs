using System;
using Ekoodi.Utilities.Test;
using Ekoodi.Utilities.Bank;

namespace bank_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestUtility.PrintGreetings();
            // Console.ReadLine();
            // biginteger
            string userInput;
            string originalAccountNumber = "";
            int parsedAccountNumber = 0;
            bool notOk = true;
            while (notOk == true)
            {
                Console.WriteLine("anna tilinumero 9-14 merkkia");
                userInput = Console.ReadLine();
                string errorMessage = "";
                try
                {
                    Console.WriteLine("Tilinumerosi on: {0}", BbanValidator.ReadAccountNumber(userInput, parsedAccountNumber));
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    Console.WriteLine("Virhe on {0} ", errorMessage);
                    Console.ReadLine();

                    /*   if (errorMessage != "")
                       {
                           notOk = true;
                           errorMessage = "";
                       }
                       else
                       {
                           notOk = false;
                       }

                 Console.WriteLine("Tilinumerosi on: {0}", BbanValidator.ReadAccountNumber(originalAccountNumber, parsedAccountNumber));
                 */            
    }
                notOk = false;
            }
            Console.ReadKey();
        }
    }
}
