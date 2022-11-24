using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Scrieti program C# (de consola) care converteste numere in virgula fixa din baza b1 in baza b2 (2 <= b1, b2, <= 16). 
// Input: b1, b2 si o secventa de cifre in baza b1 care poate sa contina si parte zecimala. 
// Output: secventa de cifre corespunzatoare in baza b2. 
// Observatii si precizari:
//    - cifrele mai mari decat 9 in baza mai mari decat 10 vor in ordine a, b, c, d, e, f. 
//    - programul va trebui sa detecteze situatia in care rezulta o fractie periodica in baza 10 sau baza tinta
//      si sa o trateze in mod adecvat. 


namespace Conversii
{
    class Program
    {
        // Valorile care trebuie scazute din codul ASCII al unei litere, respectiv unei cifre,
        // pt. a obtine valoare lor numerica
        const int valoareDeScazutDinLitera = 55;
        const int valoareDeScazutDinCifra = 48;

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
                {
                    if      (baza == 11 && input[i] > 'A') inputCorect = false;
                    else if (baza == 12 && input[i] > 'B') inputCorect = false;
                    else if (baza == 13 && input[i] > 'C') inputCorect = false;
                    else if (baza == 14 && input[i] > 'D') inputCorect = false;
                    else if (baza == 15 && input[i] > 'E') inputCorect = false;
                    else if (baza == 16 && input[i] > 'F') inputCorect = false; 
                }

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

        /// <summary> Converteste un numar intreg din baza b in baza 10 </summary>
        /// <param name="baza"> Baza in care este reprezentat numarul intreg </param>
        /// <param name="numarInBazaB"> Numarul intreg care va fi convertit in baza 10 </param>
        /// <returns> Valoarea din baza 10 a numarului dat </returns>
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

        // Efectuarea unei fractii (+ fractie periodica)
        /// <summary> Efectueaza o fractie data, cu perioada </summary>
        /// 
        static double Divide(double numarator, double numitor)
        {
            double rez = 0;

            //

            return rez;
        }

        /// <summary> Converteste partea fractionara a unui numar din baza b in baza 10 </summary>
        /// <param name="baza"> Baza in care este reprezentata partea fractionara data </param>
        /// <param name="numarInBazaB"> Partea fractionara care va fi convertita in baza 10 </param>
        /// <returns> Valoarea din baza 10 a partii fractionare date </returns>
        static double ConvertBazaBInBaza10Fractionar(int baza, string numarInBazaB)
        {
            double numarInBaza10 = 0;
            double putereB = 1 / baza;

            // TODO: need to keep fractional part as string bcs of letters

            for (int i = 0; i < numarInBazaB.Length; i++)
            {
                int cif;
                if (numarInBazaB[i] >= 'A' && numarInBazaB[i] <= 'F')
                    cif = numarInBazaB[i] - valoareDeScazutDinLitera;
                else
                    cif = numarInBazaB[i] - valoareDeScazutDinCifra;

                // TODO: functie care efectueaza (+ fractie periodica)
                //       cif * putereB => cif / (1 / putereB)

                putereB /= baza;
            }

            return numarInBaza10;
        }

        /// <summary> Converteste un numar real din baza b in baza 10 </summary>
        /// <param name="bazaB"> Baza in care este reprezentat numarul dat </param>
        /// <param name="numarInBazaB"> Numarul real care va fi convertit </param>
        /// <returns> Valoarea din baza 10 a numarului real dat </returns>
        static double ConvertBazaBInBaza10(int bazaB, string numarInBazaB)
        {   
            // Cauta indexul virgulei in sirul de caractere al numarului din baza B
            int pozitieVirgula = numarInBazaB.IndexOf('.');
            if (pozitieVirgula == -1)
                pozitieVirgula = numarInBazaB.IndexOf(',');
            
            double numarInBaza10 = 0;

            if (pozitieVirgula != -1)
            {
                // Separa partea intreaga de partea fractionara
                string parteIntreagaB = numarInBazaB.Substring(0, pozitieVirgula-1);
                string parteFractionaraB = numarInBazaB.Substring(pozitieVirgula+1);

                // numarInBaza10 = ConvertBazaBInBaza10Intreg(bazaB, parteIntreagaB) + ConvertBazaBInBaza10Fractionar(bazaB, parteFractionaraB);
            }
            else
                numarInBaza10 = ConvertBazaBInBaza10Intreg(bazaB, numarInBazaB);

            return numarInBaza10;
        }

        static void Main(string[] args)
        {
            int baza1 = CitesteBaza(1);
            int baza2 = CitesteBaza(2);
            string numarBaza1 = CitesteNumar(baza1);

            double nrBaza10 = ConvertBazaBInBaza10(baza1, numarBaza1);
            Console.WriteLine(nrBaza10);
        }
    }
}