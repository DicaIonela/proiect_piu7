using System;
using System.Configuration;
using gestionareLoc;
using NivelStocareDate;

namespace lab3piu
{
    class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string numeFisierC = ConfigurationManager.AppSettings["NumeFisierC"];
            AdministrareLoc_FisierText adminLocuri = new AdministrareLoc_FisierText(numeFisier);
            AdministrareClient_FisierText adminClient = new AdministrareClient_FisierText(numeFisierC);
            LocDeJoaca locNou = new LocDeJoaca();
            Client client = new Client();
            int nrLocuri = 0;
            int nrClienti = 0;
            OptiuneMeniu optiuneMeniu;
            string optiune;
            do
            {
                Console.WriteLine("1. Citire informatii loc de joaca de la tastatura");
                Console.WriteLine("2. Afisarea informatiilor despre ultimul loc introdus");
                Console.WriteLine("3. Afisare locuri din fisier");
                Console.WriteLine("4. Salvare loc in fisier");
                Console.WriteLine("5. Cautare loc dupa criteriu");
                Console.WriteLine("6. Citire informatii client de la tastatura");
                Console.WriteLine("7. Afisare informatii client citit de la tastatura");
                Console.WriteLine("8. Afisare clienti din fisier");
                Console.WriteLine("9. Salvare client introdus in fisier");
                Console.WriteLine("10. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                if (Enum.TryParse(optiune, out optiuneMeniu))
                {
                    switch (optiuneMeniu)
                    {
                        case OptiuneMeniu.CitireLoc:
                            locNou = CitireLocTastatura();

                            break;
                        case OptiuneMeniu.CitireClient:
                            client = CitireClientTastatura();

                            break;

                        case OptiuneMeniu.AfisareInformatiiLoc:
                            AfisareLocDeJoaca(locNou);
                            break;

                        case OptiuneMeniu.AfisareInformatiiClient:
                            AfisareClient(client);
                            break;
                        case OptiuneMeniu.AfisareLocuri:
                            LocDeJoaca[] locuridejoaca = adminLocuri.GetLocuri(out nrLocuri);
                            AfisareLocuri(locuridejoaca, nrLocuri);
                            break;
                        case OptiuneMeniu.AfisareClienti:
                            Client[] client2 = adminClient.GetClienti(out nrClienti);
                            AfisareClienti(client2, nrClienti);

                            break;
                        case OptiuneMeniu.SalvareLoc:
                            int nrLoc = ++nrLocuri;
                            locNou.nrLoc = nrLoc;
                            adminLocuri.AddLoc(locNou);

                            break;
                        case OptiuneMeniu.SalvareClient:
                            int nrClient = ++nrClienti;
                            client.nrClient = nrClient;
                            adminClient.AddClient(client);
                            break;
                        case OptiuneMeniu.CautareLoc:
                            CautareLocuriDeJoaca(adminLocuri);
                            break;
                        case OptiuneMeniu.Inchidere:
                            return;
                        default:
                            Console.WriteLine("Optiune inexistenta");
                            break;
                    }
                }
            } while (optiuneMeniu!= OptiuneMeniu.Inchidere);
            Console.ReadLine();

        }
        public enum OptiuneMeniu
        {
            CitireLoc = 1,
            AfisareInformatiiLoc = 2,
            AfisareLocuri = 3,
            SalvareLoc = 4,
            CautareLoc = 5,
            CitireClient = 6,
            AfisareInformatiiClient = 7,
            AfisareClienti = 8,
            SalvareClient = 9,
            Inchidere = 10
        }
        public static void AfisareLocuri(LocDeJoaca[] locuridejoaca, int nrLocuri)
        {
            Console.WriteLine("Locurile de joaca sunt:");
            for (int contor = 0; contor < nrLocuri; contor++)
            {
                string infoLocuri = locuridejoaca[contor].Info();
                Console.WriteLine(infoLocuri);
            }
        }
        public static void AfisareClienti(Client[] client, int nrClienti)
        {
            Console.WriteLine("Clientii sunt:");
            for (int contor = 0; contor < nrClienti; contor++)
            {
                string infoClienti = client [contor].Info();
                Console.WriteLine(infoClienti);
            }
        }
        public static LocDeJoaca CitireLocTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti adresa");
            string adresa = Console.ReadLine();

            LocDeJoaca locdejoaca = new LocDeJoaca( 0, nume, adresa);

            return locdejoaca;
        }
        public static Client CitireClientTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti varsta");
            int varsta= Convert.ToInt32(Console.ReadLine());

            Client client = new Client( nume, varsta);

            return client;
        }
        public static void AfisareLocDeJoaca(LocDeJoaca locdejoaca)
        {
            string infoLoc = string.Format("Locul de joaca {0}: {1} are adresa {2}",
                    locdejoaca.nrLoc,
                    locdejoaca.Nume ?? " NECUNOSCUT ",
                    locdejoaca.Adresa ?? " NECUNOSCUT ");

            Console.WriteLine(infoLoc);
        }
        public static void AfisareClient(Client client)
        {
            string infoClient = string.Format("Locul de joaca {0}: {1} are adresa {2}",
                    client.nrClient,
                    client.Nume ?? " NECUNOSCUT ",
                    client.Varsta);

            Console.WriteLine(infoClient);
        }
        public static void CautareLocuriDeJoaca(AdministrareLoc_FisierText adminLocuri)
        {
            Console.WriteLine("Introduceti numele locului de joaca:");
            string numeCautat = Console.ReadLine();

            LocDeJoaca[] locuriGasite = adminLocuri.CautaLocuri(numeCautat);
            int nrLocuriGasite = locuriGasite.Length;

            if (nrLocuriGasite > 0)
            {
                Console.WriteLine($"Au fost gssite {nrLocuriGasite} locuri de joaca care corespund criteriilor:");
                AfisareLocuri(locuriGasite, nrLocuriGasite);
            }
            else
            {
                Console.WriteLine("Nu au fost gasite locuri de joaca care să corespunda criteriilor.");
            }
        }
       
    }
}