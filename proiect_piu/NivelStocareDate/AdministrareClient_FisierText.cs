using gestionareLoc;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareClient_FisierText
    {
        private const int NR_MAX_CLIENTI = 50;
        private string numeFisierC;

        public AdministrareClient_FisierText(string numeFisierC)
        {
            this.numeFisierC = numeFisierC;
            Stream streamFisierText = File.Open(numeFisierC, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddClient(Client client)
        {

            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierC, true))
            {
                streamWriterFisierText.WriteLine(client.ConversieLaSir_PentruFisier());
            }
        }

        public Client[] GetClienti(out int nrClienti)
        {
            Client[] clienti = new Client[NR_MAX_CLIENTI];

            using (StreamReader streamReader = new StreamReader(numeFisierC))
            {
                string linieFisier;
                nrClienti = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    clienti[nrClienti++] = new Client(linieFisier);
                }
            }
            Array.Resize(ref clienti, nrClienti);
            return clienti ;
        }
    }
}
