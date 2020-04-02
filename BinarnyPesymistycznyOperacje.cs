using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace ConsoleApp6
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
            string typ = "Przeszukiwanie binarne - Pesymistyczny - Operacje";

            Console.WriteLine(typ);
            addRecord(typ, "BinarnyPesymistycznyOperacje.csv");
            Random rd = new Random();
            var pomiar = new Stopwatch();
            long wyszukiwany = (int)Math.Pow(2, 28);

            Console.WriteLine("Szukany element to: " + wyszukiwany);
            long tabsize = 2000000;

            for (int i = 0; i <= 30; i++)
            {
                int iloscOperacji = 0;
                int[] tab = new int[tabsize];

                for (int j = 0; j <= tabsize - 1; j++)
                {
                    tab[j] = rd.Next(0, (int)tabsize);
                }


                Array.Sort(tab);

                long left = 0;
                long right = tabsize - 1;
                long mid;

                while (left <= right)
                {

                    mid = (left + right) / 2;
                    if (tab[mid] == wyszukiwany)
                    {
                        Console.WriteLine("W tablicy " + i + " Znaleziono liczbe " + wyszukiwany + " w elemencie: " + mid);
                        iloscOperacji++;
                        break;
                    }
                    else if (tab[mid] < wyszukiwany)
                    {
                        left = mid + 1;
                        iloscOperacji++;
                    }
                    else if (tab[mid] > wyszukiwany)
                    {
                        right = mid - 1;
                        iloscOperacji++;
                    }
                    
                }

                addRecord("", tabsize, ";", iloscOperacji, "BinarnyPesymistycznyOperacje.csv");

               
                tabsize = tabsize + 8947848;
                Console.WriteLine("tabsize: " + tabsize);
            }
            Console.WriteLine("Zakonczono dzialanie programu.");
            Console.ReadKey();
        }
    }
}
