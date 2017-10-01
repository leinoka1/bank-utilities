using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;
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
            // Console.WriteLine("Input: {0}", input);
            string outputy = input + "151800";
            BigInteger.TryParse(outputy, out accNum);
            int i = 0;
            while (accNum % 97 != 1)
            {
                accNum = accNum + i;
                i++;
            }
            // Console.WriteLine("fi xx:{0}", accNum);
            ibanCode = accNum.ToString();
            // Console.WriteLine("fi xx:{0}", iban);
            ibanCheck = ibanCode.Substring(18);
            iban = "FI" + ibanCheck + (accNum / 1000000).ToString();
            // Console.WriteLine("fi xx:{0}", iban);
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
            using (var fs = new FileStream("modified-bic-codes.txt", FileMode.Open, FileAccess.Read))
            using (var sr = new System.IO.StreamReader(fs))
            {
                string outx;
                // Read file via sr.Read(), sr.ReadLine, ...
                // Console.WriteLine(sr.ReadToEnd());
                // sr.ReadLine();
                sr.ReadLine();
                outx = sr.ReadToEnd();

                Console.WriteLine(outx);
                // Console.Write(outx);
                string[] bicCodeArray = new String[100];
                //string[,] bicCodeArray = new string[,] { outx } ;
                /*{ 
                {"1", "NDEAFIHH" },
                {"2", "NDEAFIHH" },
                {"31", "HANDFIHH" },
                {"33", "ESSEFIHX" },
                {"34", "DABAFIHX" },
                {"36", "SBANFIHH" },
                {"37", "DNBAFIHX" },
                {"38", "SWEDFIHH" },
                {"39", "SBANFIHH" },
                {"400", "ITELFIHH" },
                {"402", "ITELFIHH" },
                {"403", "ITELFIHH" },
                {"405", "HELSFIHH" },
                {"406", "ITELFIHH" },
                {"407", "ITELFIHH" },
                {"408", "ITELFIHH" },
                {"410", "ITELFIHH" },
                {"411", "ITELFIHH" },
                {"412", "ITELFIHH" },
                {"414", "ITELFIHH" },
                {"415", "ITELFIHH" },
                {"416", "ITELFIHH" },
                {"417", "ITELFIHH" },
                {"418", "ITELFIHH" },
                {"419", "ITELFIHH" },
                {"420", "ITELFIHH" },
                {"421", "ITELFIHH" },
                {"423", "ITELFIHH" },
                {"424", "ITELFIHH" },
                {"425", "ITELFIHH" },
                {"426", "ITELFIHH" },
                {"427", "ITELFIHH" },
                {"428", "ITELFIHH" },
                {"429", "ITELFIHH" },
                {"430", "ITELFIHH" },
                {"431", "ITELFIHH" },
                {"432", "ITELFIHH" },
                {"435", "ITELFIHH" },
                {"436", "ITELFIHH" },
                {"437", "ITELFIHH" },
                {"438", "ITELFIHH" },
                {"439", "ITELFIHH" },
                {"440", "ITELFIHH" },
                {"441", "ITELFIHH" },
                {"442", "ITELFIHH" },
                {"443", "ITELFIHH" },
                {"444", "ITELFIHH" },
                {"445", "ITELFIHH" },
                {"446", "ITELFIHH" },
                {"447", "ITELFIHH" },
                {"448", "ITELFIHH" },
                {"449", "ITELFIHH" },
                {"450", "ITELFIHH" },
                {"451", "ITELFIHH" },
                {"452", "ITELFIHH" },
                {"454", "ITELFIHH" },
                {"455", "ITELFIHH" },
                {"456", "ITELFIHH" },
                {"457", "ITELFIHH" },
                {"458", "ITELFIHH" },
                {"459", "ITELFIHH" },
                {"460", "ITELFIHH" },
                {"461", "ITELFIHH" },
                {"462", "ITELFIHH" },
                {"463", "ITELFIHH" },
                {"464", "ITELFIHH" },
                {"470", "POPFFI22" },
                {"471", "POPFFI22" },
                {"472", "POPFFI22" },
                {"473", "POPFFI22" },
                {"474", "POPFFI22" },
                {"475", "POPFFI22" },
                {"476", "POPFFI22" },
                {"477", "POPFFI22" },
                {"478", "POPFFI22" },
                {"479", "POPFFI22" },
                {"483", "ITELFIHH" },
                {"484", "ITELFIHH" },
                {"485", "ITELFIHH" },
                {"486", "ITELFIHH" },
                {"487", "ITELFIHH" },
                {"488", "ITELFIHH" },
                {"489", "ITELFIHH" },
                {"490", "ITELFIHH" },
                {"491", "ITELFIHH" },
                {"492", "ITELFIHH" },
                {"493", "ITELFIHH" },
                {"495", "ITELFIHH" },
                {"496", "ITELFIHH" },
                {"497", "HELSFIHH" },
                {"5", "OKOYFIHH" },
                {"6", "AABAFI22" },
                {"713", "CITIFIHX" },
                {"715", "ITELFIHH" },
                {"717", "BIGKFIH1" },
                {"799", "HOLVFIHH" },
                {"8", "DABAFIHH" },

            };
            */
                // First sort by first number
                // Console.WriteLine("Alkupää on {0}", (accNum / 10000000000000000000));
                // accNum = 0;
                BigInteger firstNumber = (accNum / 10000000000000000000);
                BigInteger firstThreeNumbers = (accNum / 100000000000000000);
                BigInteger firstTwoNumbers = (accNum / 1000000000000000000);
                bool bicCodeFound = false;
                int l = 0;
                if (firstNumber == 4 || firstNumber == 7)
                {
                    // Three number group
                    Console.Write("Bank belongs to three number group ");
                    Console.WriteLine(firstThreeNumbers);
                    // int l = 0;
                    foreach (string bnum in bicCodeArray)
                    {
                        l++;
                        if (firstThreeNumbers.ToString() == bnum)
                        {
                            // Console.WriteLine(l);
                            //Console.WriteLine(bicCodeArray[l / 2, 1]);
                            bicCodeFound = true;
                        }
                    }
                }
                else if (firstNumber == 3)
                // Two number group
                {

                    Console.Write("Bank belongs to two number group ");
                    Console.WriteLine(firstTwoNumbers);
                    // int l = 0;
                    foreach (string bnum in bicCodeArray)
                    {
                        l++;
                        if (firstTwoNumbers.ToString() == bnum)
                        {
                            // Console.WriteLine(l);
                            //Console.WriteLine(bicCodeArray[l / 2, 1]);
                            bicCodeFound = true;
                        }
                    }
                }
                else
                {
                    // One number group
                    Console.Write("Bank belongs to one number group ");
                    Console.WriteLine(firstNumber);
                    // int l = 0;
                    foreach (string bnum in bicCodeArray)
                    {
                        l++;
                        if (firstNumber.ToString() == bnum)
                        {
                            // Console.WriteLine(l);
                            //Console.WriteLine(bicCodeArray[l / 2, 1]);
                            bicCodeFound = true;
                        }
                    }
                }
                if (bicCodeFound == false)
                {

                    Exception ex = new FormatException("BIC code not defined for (One number group)!");
                    throw ex;

                }
                /*int l = 0;
                foreach (string bnum in bicCodeArray)
                {                
                    l++;
                    if (firstNumber.ToString() == bnum)
                    {
                        // Console.WriteLine(l);
                        Console.WriteLine(bicCodeArray[l/2,1]);
                    }
                }
                */
            }
            return iban;
        }
    }
}
