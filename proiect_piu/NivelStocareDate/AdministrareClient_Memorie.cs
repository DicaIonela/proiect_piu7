using gestionareLoc;

namespace NivelStocareDate
{
    public class AdministrareClienti_Memorie
    {
        public const int NR_MAX_CLIENTI = 50;

        public Client[] clienti;
        public int nrClienti;

        public AdministrareClienti_Memorie()

        {
            clienti = new Client[NR_MAX_CLIENTI];
            nrClienti = 0;
        }

        public void AddClient(Client client)
        {
            clienti[nrClienti] = client;
            nrClienti++;
        }

        public Client[] GetClienti(out int nrClienti)
        {
            nrClienti = this.nrClienti;
            return clienti;
        }
    }
}