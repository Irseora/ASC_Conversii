using System;

namespace Convert
{
    class Convert
    {
        // Valorile care trebuie scazute din codul ASCII al unei litere, respectiv unei cifre,
        // pentru a obtine valoarea lor numerica
        public const int valoareDeScazutDinLitera = 55;
        public const int valoareDeScazutDinCifra = 48;

        /// <summary> Converteste un numar intreg din baza b in baza 10 </summary>
        /// <param name="baza"> Baza in care este reprezentat numarul intreg </param>
        /// <param name="numarInBazaB"> Numarul intreg care va fi convertit in baza 10 </param>
        /// <returns> Valoarea din baza 10 a numarului dat </returns>
        public static int ConvertBazaBInBaza10Intreg(int baza, string numarInBazaB)
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
        public static double ConvertBazaBInBaza10Fractionar(int baza, string numarInBazaB)
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
                // TODO: fractii periodice ???

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
            // Cauta indexul virgulei in sirul de caractere al numarului din baza B
            int pozitieVirgula = numarInBazaB.IndexOf('.');
            if (pozitieVirgula == -1)
                pozitieVirgula = numarInBazaB.IndexOf(',');
            
            double numarInBaza10 = 0;

            // Daca numarul din baza b are parte fractionara
            if (pozitieVirgula != -1)
            {
                // Separa partea intreaga de partea fractionara
                string parteIntreagaB = numarInBazaB.Substring(0, pozitieVirgula);
                string parteFractionaraB = numarInBazaB.Substring(pozitieVirgula+1);

                numarInBaza10 = ConvertBazaBInBaza10Intreg(bazaB, parteIntreagaB) + ConvertBazaBInBaza10Fractionar(bazaB, parteFractionaraB);
            }
            // Daca numarul din baza b are doar parte intreaga
            else
                numarInBaza10 = ConvertBazaBInBaza10Intreg(bazaB, numarInBazaB);

            return numarInBaza10;
        }
    }
}