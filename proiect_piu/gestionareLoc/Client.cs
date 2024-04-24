using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionareLoc
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int NUME = 0;
        private const int VARSTA = 1;
        public int nrClient { get; set; }
        public string Nume { get; set; }
        public int Varsta { get; set; }
        public string Varstas { get; set; }
        public bool EsteInLocatie { get; set; }

        public Client()
        {
            Nume = string.Empty;

        }
        public Client(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            this.Nume = dateFisier[NUME];
            this.Varsta = Convert.ToInt32(dateFisier[VARSTA]);
        }
        public Client(string nume, int varsta)
        {
            Nume = nume;
            this.Varsta = varsta;
            EsteInLocatie = false;
        }
        public Client(string nume, string varsta)
        {
            Nume = nume;
            Varstas = varsta;
            EsteInLocatie = false;
        }
        public string Info()
        {
            string info = $"Clientul:\nNume:{Nume ?? " NECUNOSCUT "} Varsta: {Varsta}";

            return info;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Nume ?? " NECUNOSCUT "),
                Varsta.ToString());

            return obiectStudentPentruFisier;
        }
    }
}