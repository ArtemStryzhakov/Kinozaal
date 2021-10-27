using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kordamine
{
    class Program
    {
        static int Saali_suurus()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Vali saali suurus [1,2,3]: ");
            int suurus = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return suurus;
        }
        static int[,] saal = new int[,] { };
        static int[] ost = new int[] { };
        static int kohad, read, mitu, mitu_veel;
        static void Saali_taitmine(int suurus)
        {
            Random rnd = new Random();
            if (suurus == 1)
            { kohad = 20; read = 10; }
            else if (suurus == 2)
            { kohad = 20; read = 20; }
            else
            { kohad = 30; read = 20; }
            saal = new int[read, kohad];
            for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);
                }
            }
        }
        static void Saal_ekraanile()
        {
            Console.Write("      ");
            for (int koht = 0; koht < kohad; koht++)
            {
                if (koht.ToString().Length == 2)
                { Console.Write(" {0}", koht + 1); }
                else
                { Console.Write("  {0}", koht + 1); }
            }

            Console.WriteLine();
            for (int rida = 0; rida < read; rida++)
            {
                Console.Write($"Rida {rida + 1}: ");
                for (int koht = 0; koht < kohad; koht++)
                {

                    Console.Write(saal[rida, koht] + "  ");
                }
                Console.WriteLine();
            }
        }
        static bool Muuk_ise()
        {
            Console.WriteLine();
            Console.Write("Rida: ");
            int pileti_rida = int.Parse(Console.ReadLine());
            Console.Write("Koht: ");
            int pileti_koht = int.Parse(Console.ReadLine());
            if (saal[pileti_rida - 1, pileti_koht - 1] == 0)
            {
                Console.WriteLine("See koht on vaba. Sinu koht on ostatud.");
                saal[pileti_rida - 1, pileti_koht - 1] = 1;
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("See koht on kinni. Valige teine ​​koht.");
                Console.WriteLine();
                return false;
            }

        }
        static bool Muuk()
        {
            Console.WriteLine();
            Console.Write("Rida: ");
            int pileti_rida = int.Parse(Console.ReadLine());
            Console.Write("Mitu piletid: ");
            mitu = int.Parse(Console.ReadLine());
            bool t = false;
            ost = new int[mitu];
            int p = (kohad - mitu) / 2;
            int k = 0;
            do
            {
                if (saal[pileti_rida - 1, p - 1] == 0)
                {
                    ost[k] = p;
                    Console.WriteLine($"koht {p} on vaba");
                    t = true;
                }
                else
                {
                    Console.WriteLine($"koht {p} kinni");
                    ost = new int[mitu];
                    k = 0;
                    p = (kohad - mitu) / 2;
                    t = false;
                }
                p++;
                k++;
            } while (mitu != k);
            if (t == true)
            {
                Console.WriteLine("Sinu kohad on:");
                foreach (var koh in ost)
                {
                    Console.WriteLine("{0}\n", koh);
                }
            }
            else
            {
                Console.WriteLine("Selles reas ei ole vabu kohti. Kas tahad teises reas otsida?");
            }
            return t;
        }
        public static void Main(string[] args)
        {
            int suurus = Saali_suurus();
            Saali_taitmine(suurus);
            while (true)
            {
                Saal_ekraanile();
                Console.WriteLine();
                Console.Write("1-ise valik, 2-masina valik: ");
                int valik = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (valik == 1)
                {
                    int koh = 0;
                    Console.Write("Mitu pileteid tahad osta?: ");
                    int kogus = Convert.ToInt32(Console.ReadLine());
                    bool a = false;
                    while (a != true)
                    {
                        for (int i = 0; i < (kohad-1) * (read-1); i++)
                        {
                            a = Muuk_ise();
                            if (a)
                            {
                                koh++;
                            }
                            if (koh == kogus)
                            {
                                break;
                            }
                        }                        
                    }
                    

                }
                else if(valik == 2)
                {
                    bool a = false;
                    while (a != true)
                    {
                        a = Muuk();
                        Saal_ekraanile();
                    }
                    break;
                }
            }
            Saal_ekraanile();
            //Console.ReadLine();
        }
    }
}