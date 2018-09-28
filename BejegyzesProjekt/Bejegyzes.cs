using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    class Bejegyzes
    {
        private string szerzo;
        private string tartalom;
        private int likeok;
        private DateTime letrejott;
        private DateTime szerkesztve;

         

        public Bejegyzes(string szerzo,string tartalom)
        {
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            letrejott = DateTime.Now;
            szerkesztve = DateTime.Now;
        }
        public string Tartalom
        {
            get
            {
                return tartalom;
            }
            set
            {
                this.tartalom = value;
                szerkesztve = DateTime.Now;
            }
        }

        public string Szerzo
        {
            get
            {
                return szerzo;
            }

           
        }
           
        public int Likeok
        {
            get { return likeok; }
        }

        public DateTime Letrejott{

            get {
                return letrejott;
            }

            }

        public DateTime Szerkesztve
        {

            get
            {
                return szerkesztve;
            }

        }

        public void Like()
        {
            this.likeok++;
        }

        public string Kiir()
        {
            string vissza="";
            vissza = this.Szerzo + ";" +
                  this.Likeok + ";" +
                  this.Letrejott + ";" +
                  this.Szerkesztve + ";" +
                  this.Tartalom;




            return vissza;
        }

        public override string ToString()
        {
            string vissza = "";

            if (this.Letrejott==this.Szerkesztve)
            {
                
                vissza = this.Szerzo +
                    " - " + this.Likeok +
                    " - " + this.Letrejott +
                    "\n" + this.Tartalom;
            }
            else
            {
                 
                vissza = this.Szerzo +
                    " - " + this.Likeok +
                    " - " + this.Letrejott +
                    "\nSzerkesztve: " +
                    this.Szerkesztve +
                    "\n" + this.Tartalom;
            }


            return vissza;
        }



    }
}
