using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        // Citeste un numar intreg din intervalul [2,16] care reprezinta o baza
        static int CitesteBaza(int nrBazei)
        {
            Console.WriteLine($"Introduceti baza {nrBazei}: ");
            int input = int.Parse(Console.ReadLine());

            while (input < 2 || input > 16)
            {
                Console.WriteLine("Baza trebuie sa fie nr. intreg din intervalul [2,16]");
                Console.WriteLine($"Introduceti baza {nrBazei}: ");
                input = int.Parse(Console.ReadLine());
            }

            return input;
        }

        // Citeste un numar reprezentat in baza data
        static double CitesteNumar(int baza)
        {
            Console.WriteLine($"Introduceti un numar din baza {baza}: ");
            double input = double.Parse(Console.ReadLine());
            return input;
        }

        // 


        static void Main(string[] args)
        {
            int baza1 = CitesteBaza(1);
            int baza2 = CitesteBaza(2);
            double numarBaza1 = CitesteNumar(baza1);


        }
    }
}