using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1NS
{
    public class Program
    {

        public static void Main()
        {

            Fraction[] fractions = new Fraction[]
            {
                new Fraction(50, 21),
                new Fraction(-50, 8),
                new Fraction(127, 521),
            };

            Console.WriteLine(fractions[1].RoundUp());

            Console.WriteLine(fractions[1].RoundDown());

            Console.WriteLine("Nie posortowane: ");
            for (int i = 0; i < fractions.Length; ++i)
                Console.WriteLine(fractions[i].ToString());

            Array.Sort(fractions);

            Console.WriteLine("Posortowane od najmiejszego: ");
            for (int i = 0; i < fractions.Length; ++i)
                Console.WriteLine(fractions[i].ToString());

            Console.WriteLine(fractions[0].Equals(fractions[0]));
        }
    }
}