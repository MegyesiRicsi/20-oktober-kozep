using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.IO;

namespace toto
{
    class EredmenyElemzo
    {
        private string Eredmenyek;

        private int DontetlenekSzama
        {
            get
            {
                return Megszamol('X');
            }
        }

        private int Megszamol(char kimenet)
        {
            int darab = 0;
            foreach (var i in Eredmenyek)
            {
                if (i == kimenet) darab++;
            }
            return darab;
        }

        public bool NemvoltDontetlenMerkozes
        {
            get
            {
                return DontetlenekSzama == 0;
            }
        }

        public EredmenyElemzo(string eredmenyek) // konstruktor
        {
            Eredmenyek = eredmenyek;
        }
    }
    /*Év;Hét;Forduló;T13p1;Ny13p1;Eredmények
       2020;18;1;0;0;2X22211X1X11X1*/
    class C
    {
        public int ev, het, fordulo, t13, ny13;
        public string eredmenyek;
        public int ossz => t13 * ny13;
        public C(string sor)
        {
            var s = sor.Split(';');
            ev = int.Parse(s[0]);
            het = int.Parse(s[1]);
            fordulo = int.Parse(s[2]);
            t13 = int.Parse(s[3]);
            ny13= int.Parse(s[4]);
            eredmenyek = s[5];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<C>();
            var sr = new StreamReader("toto.txt");
            var elso = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                lista.Add(new C(sr.ReadLine()));
            }
            Console.WriteLine($"3. feladat: Fordulok száma: {lista.Count()}");
            var teli = (from sor in lista select sor.t13).Sum();
            Console.WriteLine($"4. feladat: Telitalálatos szelvények száma: {teli} db");
            var atl = (from sor in lista  select sor.ny13*sor.t13).Average();
            Console.WriteLine($"5. feladat: Átlag: {atl:0.} Ft");

            var min = (from sor in lista where sor.ny13>0 orderby sor.ny13 select sor);
            Console.WriteLine("6. feladat:");
            Console.WriteLine("\tLegnagyobb:");
            Console.WriteLine($"\tév: {min.Last().ev}");
            Console.WriteLine($"\tHét: {min.Last().het}.");
            Console.WriteLine($"\tTelitalálatok: {min.Last().t13}.");
            Console.WriteLine($"\tNyeremeny: {min.Last().ny13} Ft");
            Console.WriteLine($"\tEredmények: {min.Last().eredmenyek}");
            Console.WriteLine();
            Console.WriteLine("\tLegkisebb:");
            Console.WriteLine($"\tév: {min.First().ev}");
            Console.WriteLine($"\tHét: {min.First().het}.");
            Console.WriteLine($"\tTelitalálatok: {min.First().t13}.");
            Console.WriteLine($"\tNyeremeny: {min.First().ny13} Ft");
            Console.WriteLine($"\tEredmények: {min.First().eredmenyek}");

            bool voltDöntetlenNélküliForduló = false;
            foreach (var i in lista)
            {
                EredmenyElemzo ee = new EredmenyElemzo(i.eredmenyek);
                if (ee.NemvoltDontetlenMerkozes)
                {
                    voltDöntetlenNélküliForduló = true;
                    break;
                }
            }
            Console.WriteLine($"8. feladat: {(voltDöntetlenNélküliForduló ? "Volt" : "Nem volt")} döntetlen nélküli forduló!");

            Console.ReadKey();
        }
    }
}
