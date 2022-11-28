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
            bool inputCorect = false;
            while (!inputCorect)
            {
                // Daca una din cifrele numarului este >= cu baza, numarul introdus nu apartine bazei date
                inputCorect = true;
                for (int i = 0; i < input.Length; i++)
                    if (input[i] > 'A' && input[i] - Convert.Convert.valoareDeScazutDinLitera >= baza)
                        inputCorect = false;

                // Daca numarul introdus nu a fost corect, afiseaza un mesaj si citeste din nou
                if (!inputCorect)
                {
                    Console.WriteLine($"\nNumarul introdus nu apartine bazei {baza}.");
                    Console.Write($"Introduceti un numar din baza {baza}: ");
                    input = Console.ReadLine();
                }
            }

            return input;
        }

        /// <summary> Verifica daca numarul dat apartine bazei date, si este un numar corect introdus </summary>
        /// <param name="numar"> Numarul care trebuie verificat </param>
        /// <param name="baza"> Baza in care ar trebui sa fie numarul dat </param>
        /// <returns> Adevarat daca numarul este corect, fals daca nu </returns>
        static bool Validate(string numar, int baza)
        {
            bool corect = true;

            int nrVirgule = 0;
            for (int i = 0; i < numar.Length; i++)
            {
                if (numar[i] == '.' || numar[i] == ',')
                {
                    // Daca are mai mult de o virgula, este gresit
                    if (nrVirgule == 1)
                        return false;
                    else
                        nrVirgule++;
                }
                else if (numar[i] > 'A' && numar[i] < 'F')
                {
                    //
                }
                else if (numar[i] < '0' || numar[i] > '9')
                    return false;
            }

            return true;
        }

        // TODO: ???
        /// <summary> Efectueaza o fractie data, cu perioada daca este cazul</summary>
        /// <param name="numarator"> Numaratorul fractiei</param>
        /// <param name="numitor"> Numitorul fractiei</param>
        /// <returns> Fractia efectuata, sub forma unui string </returns>
        static string Divide(string numarator, double numitor) // numarator, baza
        {
            string rez = "0.";

            double rest = -1;
            bool periodica = false;

            List<int> cifre = new List<int>();

            return rez;
        }  

        static void Main(string[] args)
        {
            int baza1 = CitesteBaza(1);
            int baza2 = CitesteBaza(2);
            string numarBaza1 = CitesteNumar(baza1);

            double nrBaza10 = Convert.Convert.ConvertBazaBInBaza10(baza1, numarBaza1);
            Console.WriteLine(nrBaza10);
        }
    }
}