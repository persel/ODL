using ODL.DomainModel.Common;

namespace ODL.DomainModel.Organisation
{

    public class Resultatenhet
    {
        public Resultatenhet()
        {
        }

        public Resultatenhet(string kstNr, Kostnadsstalletyp typ)
        {
            KstNr = kstNr;
            Typ = typ;
        }

        public int OrganisationId { get; private set; }

        public string KstNr { get; private set; }

        public Kostnadsstalletyp Typ
        {
            get => KostnadsstalletypString.TillEnum<Kostnadsstalletyp>();

            private set => KostnadsstalletypString = value.ToString();
        }

        public string KostnadsstalletypString { get; private set; }


        public virtual Organisation Organisation { get; private set; }

        public bool Ny => OrganisationId == default(int);
    }
}
