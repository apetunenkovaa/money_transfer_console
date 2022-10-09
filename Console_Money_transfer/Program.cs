using System;
using System.IO;
using System.Text;

namespace Console_Money_transfer
{
    class program
    {
        static void Main(string[] args)
        {
            money[] arr = Read.read();
            double transfer, trun;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!(arr[i].rub == 0 && arr[i].kop == 0))
                {
                    transfer = (arr[i].rub + arr[i].kop / 100) * 0.017;
                    arr[i].dol = transfer;

                    transfer = (arr[i].rub + arr[i].kop / 100) * 0.018;
                    arr[i].euro = transfer;

                    transfer = (arr[i].rub + arr[i].kop / 100) * 0.016;
                    arr[i].pound = transfer;

                    transfer = (arr[i].rub + arr[i].kop / 100) * 7.10;
                    arr[i].dram = transfer;

                    transfer = (arr[i].rub + arr[i].kop / 100) * 2.48;
                    arr[i].yen = transfer;
                }
                else
                {
                    if (arr[i].dol != 0)
                    {
                        transfer = arr[i].dol / 0.017;
                        trun = Math.Truncate(transfer);
                        arr[i].rub = trun;
                        transfer -= trun;
                        arr[i].kop = transfer;
                    }
                    else if (arr[i].euro != 0)
                    {
                        transfer = arr[i].euro / 0.018;
                        trun = Math.Truncate(transfer);
                        arr[i].rub = trun;
                        transfer -= trun;
                        arr[i].kop = transfer;
                    }
                    else if (arr[i].pound != 0)
                    {
                        transfer = arr[i].pound / 0.016;
                        trun = Math.Truncate(transfer);
                        arr[i].rub = trun;
                        transfer -= trun;
                        arr[i].kop = transfer;
                    }
                    else if (arr[i].dram != 0)
                    {
                        transfer = arr[i].dram / 7.10;
                        trun = Math.Truncate(transfer);
                        arr[i].rub = trun;
                        transfer -= trun;
                        arr[i].kop = transfer;
                    }
                    else if (arr[i].yen != 0)
                    {
                        transfer = arr[i].yen / 2.48;
                        trun = Math.Truncate(transfer);
                        arr[i].rub = trun;
                        transfer -= trun;
                        arr[i].kop = transfer;
                    }
                }
            }

            string path = Environment.CurrentDirectory;
            path = path.Replace(@"bin\Debug\netcoreapp3.1", "resultat.csv");
            File.Delete("resultat.csv");
            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);

            Console.WriteLine("Рубли Копейки Доллары Евро Фунт Драм Йен");
            sw.WriteLine("Рубли;Копейки;Доллары;Евро;Фунт;Драм;Йен"); 

            for (int i = 1; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i].rub} {arr[i].kop} {arr[i].dol} {arr[i].euro} {arr[i].pound} {arr[i].dram} {arr[i].yen}");
                writeInFile(arr[i].rub, sw);
                writeInFile(arr[i].kop, sw);
                writeInFile(arr[i].dol, sw);
                writeInFile(arr[i].euro, sw);
                writeInFile(arr[i].pound, sw);
                writeInFile(arr[i].dram, sw);
                writeInFile(arr[i].yen, sw);
                sw.WriteLine();
            }

            sw.Close();
        }

        static void writeInFile(double a, StreamWriter sw)
        {
            if (a == 0)
            {
                sw.Write("-;");
            }
            else
            {
                sw.Write($"{a};");
            }
        }

        public struct money
        {
            public double rub;
            public double kop;
            public double dol;
            public double euro;
            public double pound;
            public double dram;
            public double yen;
        }
    }
}