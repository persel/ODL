using ODL.DomainModel.Common;

namespace ODL.DomainModel.Organisation
{
    public enum Kostnadsstalletyp
    {
        [Visningstext("Huvudkostnadsställe")]
        H,
        [Visningstext("Gemensamt kostnadsställe")]
        G,
        [Visningstext("Bi-kostnadsställe")]
        B
    }
}
