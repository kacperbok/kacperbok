using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace ConsoleApp9
{
    class Program
    {
        public static void addRecord(string typ, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(typ);
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("", ex);
            }
        }
        public static void addRecord(string nazwa, long tabela, string przerwa, long czas, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
                {
                    file.WriteLine(nazwa + tabela + przerwa + " " + czas);
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("", ex);
            }
        }
        static void Main(string[] args)
        {
            string typ = "Przeszukiwanie liniowe - Sredni - Czas";
            
            Console.WriteLine(typ);
            addRecord(typ, "LiniowySredniCzas.csv");
            Random rd = new Random();
            var pomiar = new Stopwatch();
            int wyszukiwanycounter = 0;
            long wyszukiwany = ((int)Math.Pow(2, 28)/2);
            Console.WriteLine("Szukany element to: " + wyszukiwany);
            long tabsize = 2000000;

            for (int i = 0; i <= 30; i++)
            {

                int[] tab = new int[tabsize];
                for (int j = 0; j <= tabsize - 1; j++)
                {
                    tab[j] = rd.Next(0, (int)tabsize);
                }

                pomiar.Start();
                for (int p = 0; p < tabsize; p++)
                {
                    if (tab[p] == wyszukiwany)
                    {
                        wyszukiwanycounter++;
                        break;
                    }
                }

                pomiar.Stop();
                Console.WriteLine("W tablicy " + i + " znaleziono szukanych elementow " + wyszukiwanycounter);
                long ts = pomiar.ElapsedMilliseconds;
                ts.ToString();
                Console.WriteLine(ts);

                addRecord("", tabsize, ";", ts, "LiniowySredniCzas.csv");

                pomiar.Restart();
                wyszukiwanycounter = 0;
                tabsize = tabsize + 8947848;
                Console.WriteLine("tabsize: " + tabsize);

            }
            Console.WriteLine("Zakonczono dzialanie programu.");
            Console.ReadKey();
        }

    }
}
