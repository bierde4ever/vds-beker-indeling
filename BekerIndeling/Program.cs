using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BekerIndeling
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<Deelnemer>()
            {
                new Deelnemer() {Naam = "Erwin Greven", Rating = 1829 },
                new Deelnemer() {Naam = "Jaap Staal", Rating = 2053 },
                new Deelnemer() {Naam = "Richard van Tienhoven", Rating = 1994 },
                new Deelnemer() {Naam = "Kees Greevenbosch", Rating = 1931 },
                new Deelnemer() {Naam = "Henk Greevenbosch", Rating = 1858 },
                new Deelnemer() {Naam = "Miguel Tervooren", Rating = 1675 },
                new Deelnemer() {Naam = "Hans Hertgers", Rating = 1626 },
                new Deelnemer() {Naam = "Frits Wilbrink", Rating = 1740 },
                new Deelnemer() {Naam = "Arie van Veen", Rating = 1539 },
                new Deelnemer() {Naam = "Frank Nelemans", Rating = 1523 },
                new Deelnemer() {Naam = "Johan van Ommen", Rating = 1688 },
                new Deelnemer() {Naam = "Diderick Holtland", Rating = 1792 },
                new Deelnemer() {Naam = "Gerald Visch", Rating = 1549 },
                new Deelnemer() {Naam = "Carlo Buijvoets", Rating = 1694 },
                new Deelnemer() {Naam = "Remco Pihlajamaa", Rating = 1898 },
                new Deelnemer() {Naam = "Ron Sint-Nicolaas", Rating = 1312 }
            };
            numbers.Shuffle();
            foreach (var nr in numbers)
                Console.WriteLine(nr.Naam);
            Console.ReadKey();
        }
    }

    public class Deelnemer
    {
        public string Naam { get; set; }
        public int Rating { get; set; }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }

    }
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
