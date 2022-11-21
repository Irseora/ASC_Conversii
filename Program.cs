using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        // Valorile care trebuie scazute dintr-o litera, respectiv o cifra,
        // pt. a obtine valoare lor numerica
        const int valoareDeScazutDinLitera = 31;
        const int valoareDeScazutDinCifra = 30;

        // Citeste un numar intreg din intervalul [2,16] care reprezinta o baza
        // nrBazei = a cata baza citeste (1/2)
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

        // Converteste un numar intreg din baza b in baza 10
        static int ConvertBazaBInBaza10Intreg(int baza, string numarInBazaB)
        {
            int numarInBaza10 = 0;
            int putereB = 1;

            for (int i = numarInBazaB.Length - 1; i >= 0; i--)
            {
                if (numarInBazaB[i] >= 'A' && numarInBazaB[i] <= 'F')
                    numarInBaza10 += (numarInBazaB[i] - valoareDeScazutDinLitera) * putereB;
                else
                    numarInBaza10 += (numarInBazaB[i] - valoareDeScazutDinCifra) * putereB;

                putereB *= baza;
            }

            return numarInBaza10;
        }

        // Converteste partea fractionara a unui numar din baza b in baza 10
        static double ConvertBazaBInBaza10Fractionar(int baza, string numarInBazaB)
        {
            double numarInBaza10 = 0;

            

            return numarInBaza10;
        }

        // Converteste un numar din baza b in baza 10
        static double ConvertBazaBInBaza10(int bazaB, string numarInBazaB)
        {   
            /*
            // Converteste partea fractionara a numarului
            double putereBDouble = 1.0/10; 
            for (int i = pozVirgula+1; i < nrB.Length; i++)
            {
                if (nrB[i] >= 65 && nrB[i] <= 70)
                    nr10 += (nrB[i] - valoareDeScazutLitera) * putereBDouble;
                else
                    nr10 += (nrB[i] - valoareDeScazutCifra) * putereBDouble;

                putereBDouble /= 10;
            }*/

            // Cauta indexul virgulei in sirul de caractere al numarului din baza B
            int pozitieVirgula = numarInBazaB.IndexOf('.');
            if (pozitieVirgula == -1)
                pozitieVirgula = numarInBazaB.IndexOf(',');

            // Separa partea intreaga de partea fractionara
            string parteIntreagaB = numarInBazaB.Substring(0, pozitieVirgula-1);
            string parteFractionaraB = numarInBazaB.Substring(pozitieVirgula+1);
            
            

            
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