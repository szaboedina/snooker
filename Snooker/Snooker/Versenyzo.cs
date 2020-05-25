using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    class Versenyzo
    {
        int helyezes;
        string nev;
        string orszag;
        int nyeremeny;

        public Versenyzo(int helyezes, string nev, string orszag, int nyeremeny)
        {
            this.helyezes = helyezes;
            this.nev = nev;
            this.orszag = orszag;
            this.nyeremeny = nyeremeny;
        }

        public int Helyezes { get => helyezes; set => helyezes = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Orszag { get => orszag; set => orszag = value; }
        public int Nyeremeny { get => nyeremeny; set => nyeremeny = value; }
    }
}
