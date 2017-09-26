using System;
using Ekoodi.Utilities.Test;
using Ekoodi.Utilities.Bank;

namespace bank_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int parsedAccountNumber = 0;
            bool notOk = true;
            while (notOk == true)
            {
                Console.Write("Enter an Account Number (9-14 characters):");
                userInput = Console.ReadLine();
                string errorMessage = "";
                try
                {
                    Console.WriteLine("Your full Account Number is: {0}", BbanValidator.ReadAccountNumber(userInput, parsedAccountNumber));
                    Console.WriteLine("Checksum is valid");
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    Console.WriteLine("Error message: {0} ", errorMessage);
                    Console.ReadLine();
                }
                notOk = false;
            }
            Console.ReadKey();
        }
    }
}
