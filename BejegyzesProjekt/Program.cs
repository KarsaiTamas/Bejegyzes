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
        static void Szoveg_Textbol(string helye)
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

        private static List<Bejegyzes> bejegyez_lista = new List<Bejegyzes>();
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
            Console.ReadLine();
        }
    }
}
