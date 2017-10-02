using System;
using System.Collections.Generic;
using System.IO;

namespace file_test
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.ReadLine();

            }
        }
    }
}
