using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Ekoodi.Utilities.Bank
{
    public static class InterNatReferenceNumber
    {
        public static string CheckIntNatRefNum(string input, string output)
        {
            string refNum, firstFourChars = "", checkSum = "";
            double numericMcode;
            refNum = input.Substring(4);
            for (int i = 1; i <= 4; i++)
            {
                firstFourChars = firstFourChars + input[i - 1];
            }
            for (int i = 3; i <= 4; i++)
            {
                checkSum = checkSum + input[i - 1];
            }
            string lastPartRefNum = "";
            for (int i = 5; i <= input.Length; i++)
            {
                lastPartRefNum = lastPartRefNum + input[i - 1];
            }
            string firstTwoLetters = "";
            for (int i = 1; i <= 2; i++)
            {
                firstTwoLetters = firstTwoLetters + input[i - 1];
            }
            // Letters to digits
            char[] xx = new char[2];
            xx = firstTwoLetters.ToCharArray();
            string a = "", b = "", mCode;
            string[,] intNatLetterArray = new string[,]
            {
            {"10", "A" },{"11", "B" },{"12", "C" },{"13", "D" },{"14", "E" },{"15", "F" },{"16", "G" },{"17", "H" },{"18", "I" },
            {"19", "J" },{"20", "K" },{"21", "L" },{"22", "M" },{"23", "N" },{"24", "O" },{"25", "P" },{"26", "Q" },{"27", "R" },
            {"28", "S" },{"29", "T" },{"30", "U" },{"31", "V" },{"32", "W" },{"33", "X" },{"34", "Y" },{"35", "Z" },
            };
            for (int i = 0; i <= 25; i++)
            {
                if (intNatLetterArray[i, 1] == xx[0].ToString())
                {
                    a = intNatLetterArray[i, 0];
                }
            }
            for (int i = 0; i <= 25; i++)
            {
                if (intNatLetterArray[i, 1] == xx[1].ToString())
                {
                    b = intNatLetterArray[i, 0];
                }
            }
            mCode = lastPartRefNum + a + b + checkSum;
            // Checking Check Number
            numericMcode = Convert.ToDouble(mCode);
            if (numericMcode % 97 == 1)
                Console.WriteLine("{0} - OK! ", input);
            else
            {
                Exception ex = new FormatException("International Reference Number is not valid, checksum is incorrect!");
                throw ex;
            }
            return input;
        }
        public static string CreateIntNatRefNum(string input, string output)
        {
            string mCodeBase, intNatRefNum;
            double numericMcodeBase, numericMcode;
            mCodeBase = input + "2715" + "00";
            numericMcodeBase = Convert.ToDouble(mCodeBase);
            numericMcode = numericMcodeBase + (98 - (numericMcodeBase % 97));
            intNatRefNum = "RF" + (98 - (numericMcodeBase % 97)).ToString() + input;
            return intNatRefNum;
        }
    }
}
