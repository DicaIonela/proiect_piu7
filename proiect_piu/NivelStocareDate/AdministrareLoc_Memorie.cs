using gestionareLoc;

namespace NivelStocareDate
{
    public class AdministrareLoc_Memorie
    {
        public const int NR_MAX_LOCURI = 50;

        public LocDeJoaca[] locuri;
        public int nrLocuri;

        public AdministrareLoc_Memorie()

        {
            locuri = new LocDeJoaca[NR_MAX_LOCURI];
            nrLocuri = 0;
        }

        public void AddLoc(LocDeJoaca locdejoaca)
        {
            locuri[nrLocuri] = locdejoaca;
            nrLocuri++;
        }

        public LocDeJoaca[] GetStudenti(out int nrLocuri)
        {
            nrLocuri = this.nrLocuri;
            return locuri;
        }
    }
}