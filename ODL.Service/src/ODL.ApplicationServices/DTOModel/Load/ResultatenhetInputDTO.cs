using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.DTOModel
{
    public class ResultatenhetInputDTO : InputDTO
    {
        public string Namn { get; set; }
        public string OrganisationsId { get; set; }
        public string KostnadsstalleNr { get; set; }
        public string Typ { get; set; }
    }
}