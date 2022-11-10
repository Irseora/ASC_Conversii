using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        // Valoarea care trebuie scazuta dintr-o litera, care reprezinta o cifra intr-o baza > 10, pt. a-i afla valoarea
        const int valoareDeScazutLitera = 55;

        // Valoarea care trebuie scazuta din valoarea ASCII a unei cifre pt. a obtine cifra
        const int valoareDeScazutCifra = '0';

        // Citeste un numar intreg din intervalul [2,16] care reprezinta o baza
        static int CitesteBaza(int nrBazei)
        {
            Console.Write($"Introduceti baza {nrBazei}: ");
            int input = int.Parse(Console.ReadLine());

            while (input < 2 || input > 16)
            {
                Console.WriteLine("\nBaza trebuie sa fie nr. intreg din intervalul [2,16].");
                Console.Write($"Introduceti baza {nrBazei}: ");
                input = int.Parse(Console.ReadLine());
            }

            return input;
        }

        // Citeste un numar reprezentat in baza data
        static string CitesteNumar(int baza)
        {
            Console.Write($"Introduceti un numar din baza {baza}: ");
            string input = Console.ReadLine();

            bool ok = false;
            while (!ok)
            {
                ok = true;

                for (int i = 0; i < input.Length; i++)
                {
                    if      (baza == 11 && input[i] > 'A') ok = false;
                    else if (baza == 12 && input[i] > 'B') ok = false;
                    else if (baza == 13 && input[i] > 'C') ok = false;
                    else if (baza == 14 && input[i] > 'D') ok = false;
                    else if (baza == 15 && input[i] > 'E') ok = false;
                    else if (baza == 16 && input[i] > 'F') ok = false; 
                }

                if (!ok)
                {
                    Console.WriteLine($"\nNumarul introdus nu apartine bazei {baza}.");
                    Console.Write($"Introduceti un numar din baza {baza}: ");
                    input = Console.ReadLine();
                }
            }

            return input;
        }

        // TODO: fractii periodice
        // Converteste un numar din baza b in baza 10
        static double ConvBazaBInBaza10(int b, string nrB)
        {
            double nr10 = 0;
            int pozVirgula = nrB.IndexOf('.');

            // Daca nu are parte fractionara
            if (pozVirgula == -1)
                pozVirgula = nrB.Length;
            
            // Converteste partea intreaga a numarului
            int putereBInt = 1;
            for (int i = pozVirgula-1; i >= 0; i--)
            {
                if (nrB[i] >= 65 && nrB[i] <= 70)
                    nr10 += (nrB[i] - valoareDeScazutLitera) * putereBInt;
                else
                    nr10 += (nrB[i] - valoareDeScazutCifra) * putereBInt;

                putereBInt *= b;
            }

            // Converteste partea fractionara a numarului
            double putereBDouble = 1.0/10; 
            for (int i = pozVirgula+1; i < nrB.Length; i++)
            {
                if (nrB[i] >= 65 && nrB[i] <= 70)
                    nr10 += (nrB[i] - valoareDeScazutLitera) * putereBDouble;
                else
                    nr10 += (nrB[i] - valoareDeScazutCifra) * putereBDouble;

                putereBDouble /= 10;
            }

            Console.WriteLine(nr10);
            return nr10;
        }


        static void Main(string[] args)
        {
            int baza1 = CitesteBaza(1);
            int baza2 = CitesteBaza(2);
            string numarBaza1 = CitesteNumar(baza1);

            double nrBaza10 = ConvBazaBInBaza10(baza1, numarBaza1);
        }
    }
}