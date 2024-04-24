using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionareLoc
{
    public class LocDeJoaca
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int NRLOC = 0;
        private const int NUME = 1;
        private const int ADRESA = 2;
        public int nrLoc { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }

        public LocDeJoaca(int nrLoc, string nume, string adresa)
        {
            this.nrLoc = nrLoc;
            Nume = nume;
            Adresa = adresa;
        }
        public LocDeJoaca()
        {
            Nume = Adresa = string.Empty;
        }
        public LocDeJoaca(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            this.nrLoc = Convert.ToInt32(dateFisier[NRLOC]);
            this.Nume = dateFisier[NUME];
            this.Adresa= dateFisier[ADRESA];
        }
        public string Info()
        {
            string info = $"Locul de joaca:\nNume:{Nume ?? " NECUNOSCUT "} Adresa: {Adresa ?? " NECUNOSCUT "}";

            return info;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                nrLoc.ToString(),
                (Nume ?? " NECUNOSCUT "),
                (Adresa ?? " NECUNOSCUT "));

            return obiectStudentPentruFisier;
        }
    }
}