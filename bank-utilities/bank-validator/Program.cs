using System;
using Ekoodi.Utilities.Test;
using Ekoodi.Utilities.Bank;

namespace bank_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string userInput;
            string bban = "";
            int parsedAccountNumber = 0;
            bool notOk = true;
            string iban = "";
            /* while (notOk == true)
            {
                Console.Write("Enter an Account Number (9-14 characters):");
                userInput = Console.ReadLine();
                string errorMessage = "";
                try
                {
                    Console.WriteLine("Your full Account Number is: {0}", BbanValidator.ReadAccountNumber(userInput, parsedAccountNumber));
                    bban = BbanValidator.ReadAccountNumber(userInput, parsedAccountNumber);
                    Console.WriteLine("BBAN Checksum is valid");
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    Console.WriteLine("Error message: {0} ", errorMessage);
                    Console.ReadLine();
                }
                notOk = false;
            }
            */
            try
            {
                //IbanValidator.ReadAccountNumber(ban, iban);
                bban = "50660500001234";
                iban = IbanValidator.ReadBbanAccountNumber(bban, iban);
                Console.WriteLine("IBAN is: {0}", iban);

            }
            catch (Exception ex)
            {
                string errorMessage = "";
                errorMessage = ex.Message;
                Console.WriteLine("Error message: {0} ", errorMessage);
                Console.ReadLine();
            }
            // iban = IbanValidator.ReadBbanAccountNumber(bban, iban);
            // Console.WriteLine("IBAN is: {0}", iban);
            // Nat Ref Number
            string natRefNum, output = "";
            // natRefNum = NationalRefNumberCheck(userInput, output);

            try
            {
                Console.WriteLine("Enter National Reference Number");
                userInput = Console.ReadLine();
                //Console.WriteLine("Your full Account Number is: {0}", BbanValidator.ReadAccountNumber(userInput, parsedAccountNumber));
                natRefNum = National_refernce_number.NationalRefNumberCheck(userInput, output);
                Console.WriteLine("National Reference Number {0} - OK", natRefNum);
            }
            catch (Exception ex)
            {
                string errorMessage = "";
                errorMessage = ex.Message;
                Console.WriteLine("Error message: {0} ", errorMessage);
                Console.ReadLine();
            }
            Console.WriteLine("Enter National Reference Number without Checksum digit");
            userInput = Console.ReadLine();
            natRefNum = National_refernce_number.NationalRefNumberCreateCheckSum(userInput, output);
            Console.WriteLine("National Reference Number: {0} ", natRefNum);
            //
            // Many NatRefNums
            //
            string userInputN, checkSum;
            string groupedToFiveNumberBlocks;
            int numOfNatRefNums, lastNumber = 0;
            Console.WriteLine("Enter National Reference Number basepart");
            userInput = Console.ReadLine();
            Console.WriteLine("Enter amout of National Reference Numbers");
            userInputN = Console.ReadLine();
            int.TryParse(userInputN, out numOfNatRefNums);
            long numericUserInput;
            for (int i = 0; i < numOfNatRefNums; i++)
            {
                numericUserInput = Convert.ToInt64(userInput) + lastNumber;
                natRefNum = National_refernce_number.NationalRefNumberCreateCheckSum(numericUserInput.ToString(), output);
                groupedToFiveNumberBlocks = "";
                int k = 0;
                foreach (Char c in natRefNum)
                {
                    if (k % 5 == 0)
                        groupedToFiveNumberBlocks = groupedToFiveNumberBlocks + " " + c;
                    else
                        groupedToFiveNumberBlocks = groupedToFiveNumberBlocks + c;
                    k++;
                }
                Console.WriteLine(groupedToFiveNumberBlocks);
                lastNumber = lastNumber + 1;
            }
            Console.ReadKey();
        }
    }
}
