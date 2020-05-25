using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    class Program
    {
        static List<Versenyzo> versenyzok;
        static void Main(string[] args)
        {
            try
            {
                Feladat2();
            }
            catch (IOException)
            {
                Console.WriteLine("A fájl beolvasása sikertelen! A program leáll");
                return;
            }

            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.ReadLine();
        }

        private static void Feladat7()
        {
            Console.WriteLine("7. feladat: Statisztika");
            var statisztika = new Dictionary<string, int>();
            foreach (var versenyzo in versenyzok)
            {
                if (statisztika.ContainsKey(versenyzo.Orszag))
                {
                    statisztika[versenyzo.Orszag]++;
                }
                else
                {
                    statisztika.Add(versenyzo.Orszag, 1);
                }
            }
            foreach (var stat in statisztika)
            {
                if (stat.Value > 4)
                {
                    Console.WriteLine(@"    {0} - {1} fő", stat.Key, stat.Value);
                }
            }
        }

        private static void Feladat6()
        {
            //bool van = versenyzok.Any(x => x.Orszag.ToLower().Contains("norvég"));
            bool van = false;
            foreach (var versenyzo in versenyzok)
            {
                if (versenyzo.Orszag.ToLower().Contains("norvég"))
                {
                    van = true;
                    break;
                }
            }
            Console.WriteLine("6. feladat: A versenyzők között {0} norvég versenyző.", van ? "van" : "nincs");
        }

        private static void Feladat5()
        {
            Versenyzo legjobb = null;
            foreach (var versenyzo in versenyzok)
            {
                if (versenyzo.Orszag.Equals("Kína"))
                {
                    if (legjobb == null)
                    {
                        legjobb = versenyzo;
                    }
                    else
                    {
                        if (legjobb.Nyeremeny < versenyzo.Nyeremeny)
                        {
                            legjobb = versenyzo;
                        }
                    }
                }
            }

            Console.WriteLine(@"5. feladat: A legjobban kereső kínai versenyző:
    Helyezés: {0}
    Név: {1}
    Ország: {2}
    Nyeremény összege: {3} Ft", legjobb.Helyezes, legjobb.Nev, legjobb.Orszag, legjobb.Nyeremeny*380);
        }

        private static void Feladat4()
        {
            //double atlag = versenyzok.Average<Versenyzo>((x) => x.Nyeremeny);
            double osszeg = 0;
            foreach (var versenyzo in versenyzok)
            {
                osszeg += versenyzo.Nyeremeny;
            }
            double atlag = osszeg / versenyzok.Count();
            Console.WriteLine("4. feladat: A versenyzők átlagosan {0:0.00} fontot kerestek", atlag);
        }

        private static void Feladat3()
        {
            Console.WriteLine("3. feladat: A világranglistán {0} versenyző szerepel", versenyzok.Count);
        }

        private static void Feladat2()
        {
            versenyzok = new List<Versenyzo>();

            using (var sr = new StreamReader("snooker.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    int helyezes = int.Parse(sor[0]);
                    string nev = sor[1];
                    string orszag = sor[2];
                    int nyeremeny = int.Parse(sor[3]);
                    var v = new Versenyzo(helyezes, nev, orszag, nyeremeny);
                    versenyzok.Add(v);
                }
            }
        }
    }
}
