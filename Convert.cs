using System;

namespace Convert
{
    class Convert
    {
        // Valorile care trebuie scazute din codul numeric al unui caracter
        // pentru a obtine valoarea lui numerica
        public const int valoareDeScazutDinLitera = 55;
        public const int valoareDeScazutDinCifra = 48;

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

        /// <summary> Converteste partea fractionara a unui numar din baza b in baza 10 </summary>
        /// <param name="baza"> Baza in care este reprezentata partea fractionara data </param>
        /// <param name="numarInBazaB"> Partea fractionara care va fi convertita in baza 10 </param>
        /// <returns> Valoarea din baza 10 a partii fractionare date </returns>
        static double ConvertBazaBInBaza10Fractionar(int baza, string numarInBazaB)
        {
            double numarInBaza10 = 0;
            double putereB = 1.0 / baza;

            for (int i = 0; i < numarInBazaB.Length; i++)
            {
                int cif;
                if (numarInBazaB[i] >= 'A' && numarInBazaB[i] <= 'F')
                    cif = numarInBazaB[i] - valoareDeScazutDinLitera;
                else
                    cif = numarInBazaB[i] - valoareDeScazutDinCifra;

                numarInBaza10 += cif * putereB;

                putereB /= baza;
            }

            return numarInBaza10;
        }

        /// <summary> Converteste un numar real din baza b in baza 10 </summary>
        /// <param name="bazaB"> Baza in care este reprezentat numarul dat </param>
        /// <param name="numarInBazaB"> Numarul real care va fi convertit </param>
        /// <returns> Valoarea din baza 10 a numarului real dat </returns>
        public static double ConvertBazaBInBaza10(int bazaB, string numarInBazaB)
        {
            // Cauta indexul virgulei (sau punctului) in sirul de caractere al numarului din baza B
            int pozitieVirgula = numarInBazaB.IndexOf('.');
            if (pozitieVirgula == -1)
                pozitieVirgula = numarInBazaB.IndexOf(',');

            // Daca numarul din baza b are si parte fractionara
            if (pozitieVirgula != -1)
            {
                // Separa partea intreaga de partea fractionara
                string parteIntreagaB = numarInBazaB.Substring(0, pozitieVirgula);
                string parteFractionaraB = numarInBazaB.Substring(pozitieVirgula+1);

                return ConvertBazaBInBaza10Intreg(bazaB, parteIntreagaB) + ConvertBazaBInBaza10Fractionar(bazaB, parteFractionaraB);
            }
            // Daca numarul din baza b are doar parte intreaga
            else
                return ConvertBazaBInBaza10Intreg(bazaB, numarInBazaB);
        }

        /// <summary> Converteste un numar intreg din baza 10 in baza b </summary>
        /// <param name="baza"> Baza tinta in care trebuie convertit numarul intreg </param>
        /// <param name="numarInBazaB"> Numarul intreg care va fi convertit </param>
        /// <returns> Valoarea din baza data a numarului dat </returns>
        static string ConvertBaza10InBazaBIntreg(int bazaB, int numarInBaza10)
        {
            string numarInBazaB = "";

            while (numarInBaza10 > 0)
            {
                numarInBazaB = (numarInBaza10 % bazaB).ToString() + numarInBazaB;

                numarInBaza10 /= bazaB;
            }

            return numarInBazaB;
        }

        /// <summary> Converteste partea fractionara a unui numar din baza 10 in baza b </summary>
        /// <param name="baza"> Baza in care trebuie convertita partea fractionara data </param>
        /// <param name="numarInBazaB"> Partea fractionara care va fi convertita </param>
        /// <returns> Valoarea din baza b a partii fractionare date </returns>
        static string ConvertBaza10InBazaBFractionar(int bazaB, double numarInBaza10)
        {
            string numarInbazaB = "";

            while ((int)numarInBaza10 != numarInBaza10)
            {
                numarInBaza10 -= Math.Truncate(numarInBaza10);

                numarInbazaB += Math.Truncate(numarInBaza10 * bazaB).ToString();

                numarInBaza10 *= bazaB;
            }

            return numarInbazaB;
        }

        /// <summary> Converteste un numar real din baza 10 in baza b </summary>
        /// <param name="bazaB"> Baza tinta in care trebuie convertit numarul dat </param>
        /// <param name="numarInBaza10"> Numarul care va fi convertit </param> 
        /// <returns> Valoarea din baza b a numarului real dat </param>
        public static string ConvertBaza10InBazaB(int bazaB, double numarInBaza10)
        {
            if (bazaB == 10)
                return numarInBaza10.ToString();

            int parteIntreagaBaza10 = (int)Math.Truncate(numarInBaza10);
            double parteFractionaraBaza10 = numarInBaza10 - parteIntreagaBaza10;

            // Daca numarul din baza 10 are si parte fractionara
            if (parteFractionaraBaza10 != 0)
            {
                string parteIntreagaBazaB = ConvertBaza10InBazaBIntreg(bazaB, (int)numarInBaza10);
                string parteFractionaraBazaB = ConvertBaza10InBazaBFractionar(bazaB, numarInBaza10);

                return parteIntreagaBazaB + '.' + parteFractionaraBazaB;
            }
            // Daca numarul din baza 10 are doar parte intreaga
            else
            {
                return ConvertBaza10InBazaBIntreg(bazaB, (int)numarInBaza10);
            }
        }

    }
}