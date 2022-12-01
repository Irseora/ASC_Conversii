using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convert;

// Scrieti program C# (de consola) care converteste numere in virgula fixa din baza b1 in baza b2 (2 <= b1, b2, <= 16). 
// Input: b1, b2 si o secventa de cifre in baza b1 care poate sa contina si parte zecimala. 
// Output: secventa de cifre corespunzatoare in baza b2. 
// Observatii si precizari:
//    - cifrele mai mari decat 9 in baza mai mari decat 10 vor in ordine a, b, c, d, e, f
//    - programul va trebui sa detecteze situatia in care rezulta o fractie periodica in baza 10 sau baza tinta
//      si sa o trateze in mod adecvat

namespace Conversii
{
    class Program
    {
        /// <summary> Citeste un numar intreg din intervalul [2,16] care reprezinta o baza </summary>
        /// <param name="numarulBazei"> A cata baza este citita (1/2) </param>
        /// <returns> Baza citita </returns>
        static int CitesteBaza(int numarulBazei)
        {
            Console.Write($"Introduceti baza {numarulBazei}: ");
            int input = int.Parse(Console.ReadLine());

            while (input < 2 || input > 16)
            {
                Console.WriteLine("\nBaza trebuie sa fie nr. intreg din intervalul [2,16].");
                Console.Write($"Introduceti baza {numarulBazei}: ");
                input = int.Parse(Console.ReadLine());
            }

            return input;
        }

        /// <summary> Citeste un numar reprezentat intr-o baza data </summary>
        /// <param name="baza"> Baza numarului citit </param>
        /// <returns> Numarul citit </returns>
        static string CitesteNumar(int baza)
        {
            Console.Write($"Introduceti un numar din baza {baza}: ");
            string input = Console.ReadLine();

            // Citeste pana primeste date de intrare corecte
            while (!Validate(input, baza))
            {
                Console.WriteLine($"\nNumarul introdus nu apartine bazei {baza}.");
                Console.Write($"Introduceti un numar din baza {baza}: ");
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary> Verifica daca numarul dat apartine bazei date, si este un numar corect introdus </summary>
        /// <param name="numar"> Numarul care trebuie verificat </param>
        /// <param name="baza"> Baza in care ar trebui sa fie numarul dat </param>
        /// <returns> Adevarat daca numarul este corect, fals daca nu </returns>
        static bool Validate(string numar, int baza)
        {
            int nrVirgule = 0;
            for (int i = 0; i < numar.Length; i++)
            {
                if (numar[i] == '.' || numar[i] == ',')
                {
                    // Daca are mai mult de o virgula, numarul este gresit
                    if (nrVirgule == 1)
                        return false;
                    else
                        nrVirgule++;
                }
                // Daca una dintre cifre este mai mare sau egala cu baza, numarul este gresit
                else if ((numar[i] >= '0' && numar[i] <= '9') || (numar[i] >= 'A' && numar[i] <= 'F'))
                {
                    if (Char.IsDigit(numar[i]))
                    {
                        if (numar[i] - Convert.BazaBinBaza10.valoareDeScazutDinCifra >= baza)
                            return false;
                    }
                    else
                    {
                        if (numar[i] - Convert.BazaBinBaza10.valoareDeScazutDinLitera >= baza)
                            return false;
                    }
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Programul converteste un numar real din baza b1 in baza b2.");
            Console.WriteLine("-----------------------------------------------------------");

            int baza1 = CitesteBaza(1);
            int baza2 = CitesteBaza(2);

            string numarPrimaBaza = CitesteNumar(baza1);
            double numarBaza10 = Convert.BazaBinBaza10.Convert(baza1, numarPrimaBaza);
            string numarADouaBaza = Convert.Baza10InBazaB.Convert(baza2, numarBaza10);

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"{numarPrimaBaza} ({baza1}) = {numarADouaBaza} ({baza2})");
        }
    }
}