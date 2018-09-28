using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BejegyzesProjekt
{
    class Program
    {
        public static void Szoveg_Textbol(string helye)
        {
            StreamReader olvas = new StreamReader(helye);
            while (!olvas.EndOfStream)
            {
                string sor=olvas.ReadLine();
                string[] adatok = sor.Split(';');
                bejegyez_lista.Add(new Bejegyzes(adatok[0], adatok[1]));
            }

            olvas.Close();
        }

        public static void Kiir_Textbe(string helye)
        {
            StreamWriter kiir = new StreamWriter(helye,false,Encoding.UTF8);
            for (int i = 0; i < bejegyez_lista.Count; i++)
            {
                kiir.WriteLine(bejegyez_lista[i].Kiir());
            }

            kiir.Close();
        }

        private static List<Bejegyzes> bejegyez_lista = new List<Bejegyzes>();
        public static bool Van_E_35_Tobb(List<Bejegyzes> lista_bejegy)
        {
            for (int i = 0; i < lista_bejegy.Count; i++)
            {
                if (lista_bejegy[i].Likeok>35)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Van_E_15_Kissebb(List<Bejegyzes> lista_bejegy)
        {
            for (int i = 0; i < lista_bejegy.Count; i++)
            {
                if (lista_bejegy[i].Likeok < 15)
                {
                    return true;
                }
            }
            return false;
        }

        public static void Rendez_Csokkeno(List<Bejegyzes> lista_bejegy)
        {
            for (int i = 0; i < lista_bejegy.Count; i++)
            {
                for (int j = lista_bejegy.Count-1; j > i; j--)
                {
                    if (lista_bejegy[i].Likeok< lista_bejegy[j].Likeok)
                    {
                        Bejegyzes csere= lista_bejegy[i];
                        lista_bejegy[i] = lista_bejegy[j];
                        lista_bejegy[j] = csere;

                    }
                }
            }
        }

        public static int Legnepszerubb_Bejegyzes(List<Bejegyzes> lista_bejegy)
        {
            int max= lista_bejegy[0].Likeok;
            int vissza = 0;
            for (int i = 0; i < lista_bejegy.Count; i++)
            {
                if (lista_bejegy[i].Likeok>max)
                {
                    max = lista_bejegy[i].Likeok;
                    vissza = i;
                }
            }

            return vissza;
        } 

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Bejegyzes jegyez = new Bejegyzes("sanyi", "jóska pista megcsinálta");
            Console.WriteLine(jegyez);
            Console.WriteLine();
            
            bejegyez_lista.Add(new Bejegyzes("jóska", "a disznó büdi"));
            bejegyez_lista.Add(new Bejegyzes("pista", "a sövény nagyranőtt"));
            foreach (var item in bejegyez_lista)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            int darab_szam;
            string beker = "";
            do
            {
                Console.Write("Hány bejegyzést szeretne hozzáadni: ");
                 beker = Console.ReadLine();


            } while (int.TryParse(beker,out darab_szam)==false);

            int a = darab_szam;
            if (darab_szam<0)
            {
                a = 0;
            }

            do
            {
                if (a > 0)
                {
                    Console.WriteLine("Kérek egy szerzot");
                    string szerzo = Console.ReadLine();
                    Console.WriteLine("Kérem a tartalmat");
                    string tartalom = Console.ReadLine();
                    bejegyez_lista.Add(new Bejegyzes(szerzo, tartalom));
                    a--;
                }
            } while (a>0);
            Szoveg_Textbol("bejegyzesek.txt");
            foreach (var item in bejegyez_lista)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < bejegyez_lista.Count*20; i++)
            {
                int szam = rnd.Next(0, bejegyez_lista.Count);
                bejegyez_lista[szam].Like();
            }
            Console.WriteLine();


            Console.WriteLine("Kérem változtassa meg a 2. bejegyzest");
            bejegyez_lista[1].Tartalom = Console.ReadLine();


            foreach (var item in bejegyez_lista)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("A legnépszerűbb bejegyzes: \n"+
                bejegyez_lista[Legnepszerubb_Bejegyzes(bejegyez_lista)]);
            Console.WriteLine("A lájkjai száma: "+ bejegyez_lista[Legnepszerubb_Bejegyzes(bejegyez_lista)].Likeok);
            if (Van_E_35_Tobb(bejegyez_lista)==true)
            {
                Console.WriteLine("Van olyan bejegyzés ami 35-nél több liket kapott.");
            }else
            {
                Console.WriteLine("Nincs olyan bejegyzés ami 35-nél több liket kapott.");
            }
            if (Van_E_15_Kissebb(bejegyez_lista) == true)
            {
                Console.WriteLine("Van olyan bejegyzés ami 15-nél kevesebb liket kapott.");
            }
            else
            {
                Console.WriteLine("Nincs olyan bejegyzés ami 15-nél kevesebb liket kapott.");
            }
            Rendez_Csokkeno(bejegyez_lista);

            foreach (var item in bejegyez_lista)
            {
                Console.WriteLine(item);
            }
            Kiir_Textbe("bejegyzesek_rendezett.txt");
            Console.ReadLine();
        }
    }
}
