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
            string typ = "Przeszukiwanie liniowe - Sredni - Operacje";

            Console.WriteLine(typ);
            addRecord(typ, "LiniowySredniOperacje.csv");
            Random rd = new Random();
            long wyszukiwany = (int)Math.Pow(2, 28);
            Console.WriteLine("Szukany element to: " + wyszukiwany);
            long tabsize = 2000000;

            for (int i = 0; i <= 30; i++)
            {

                int[] tab = new int[tabsize];
                long iloscOperacji = 0;
                for (int j = 0; j <= tabsize - 1; j++)
                {
                    tab[j] = rd.Next(0, (int)tabsize);
                }
             
                for (int p = 0; p < tabsize; p++)
                {
                    iloscOperacji++;
                    if (tab[p] == wyszukiwany)
                    {
                        Console.WriteLine("Znaleziono wyszukiwany element");
                        break;
                    }
                }
     
                Console.WriteLine("W celu przeszukania tablicy " + i + " wykonano " + iloscOperacji + " operacji.");
                addRecord("", tabsize, ";", iloscOperacji, "LiniowySredniOperacje.csv");

                tabsize = tabsize + 8947848;
                Console.WriteLine("tabsize: " + tabsize);

            }
            Console.WriteLine("Zakonczono dzialanie programu.");
            Console.ReadKey();
        }

    }
}
