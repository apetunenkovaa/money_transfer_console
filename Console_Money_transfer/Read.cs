using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Console_Money_transfer
{
    class Read
    {
        public static program.money[] read()
        {
            program.money[] arr = new program.money[0];
            string path = Environment.CurrentDirectory;
            path = path.Replace("bin\\Debug\\netcoreapp3.1", "dataMoney.csv");
            string[] l = File.ReadAllLines(path, Encoding.Default);
            foreach (var line in l)
            {
                Array.Resize(ref arr, arr.Length + 1);
                string[] s = line.Split(';');
                program.money a = new program.money();

                check(s[0], out arr[arr.Length - 1].rub);
                check(s[1], out arr[arr.Length - 1].kop);
                check(s[2], out arr[arr.Length - 1].dol);
                check(s[3], out arr[arr.Length - 1].euro);
                check(s[4], out arr[arr.Length - 1].pound);
                check(s[5], out arr[arr.Length - 1].dram);
                check(s[6], out arr[arr.Length - 1].yen);
            }
            return arr;
        }

        static void check(string s, out double a)
        {
            if (Regex.IsMatch(s, @"^[0-9]+$") || s.Contains(','))
            {
                if (!String.IsNullOrEmpty(s))
                {
                    a = Convert.ToDouble(s);
                }
                else
                {
                    a = 0;
                }
            }
            else
            {
                a = 0;
            }
        }
    }
}