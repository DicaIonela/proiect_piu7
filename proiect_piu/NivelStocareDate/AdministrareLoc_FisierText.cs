using gestionareLoc;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareLoc_FisierText
    {
        private const int NR_MAX_LOCURI = 50;
        private string numeFisier;

        public AdministrareLoc_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddLoc(LocDeJoaca locdejoaca)
        {
            
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(locdejoaca.ConversieLaSir_PentruFisier());
            }
        }

        public LocDeJoaca[] GetLocuri(out int nrLocuri)
        {
            LocDeJoaca[] locuridejoaca = new LocDeJoaca[NR_MAX_LOCURI];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrLocuri = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    locuridejoaca[nrLocuri++] = new LocDeJoaca(linieFisier);
                }
            }
            Array.Resize(ref locuridejoaca, nrLocuri);
            return locuridejoaca;
        }
        public LocDeJoaca[] CautaLocuri(string criteriu)
        {
            int nrLocuri;
            LocDeJoaca[] toateLocurile = GetLocuri(out nrLocuri);
            List<LocDeJoaca> locuriGasite = new List<LocDeJoaca>();
            foreach (LocDeJoaca loc in toateLocurile)
            {
                if (loc != null && loc.Nume != null && loc.Adresa != null && (loc.Nume.Contains(criteriu) || loc.Adresa.Contains(criteriu)))
                {
                    locuriGasite.Add(loc);
                }
            }
            return locuriGasite.ToArray();
        }
    }
}
