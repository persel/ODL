using ODL.DomainModel.Common;

namespace ODL.ApplicationServices.DTOModel.Load
{
    public abstract class InputDTO : ValidatableDTO
    {
        public virtual string SystemId { get; set;}

        public string UppdateradDatum { get; set; }

        public string UppdateradAv { get; set; }

        public string SkapadDatum { get; set; }

        public string SkapadAv { get; set; }
        
        public Metadata GetMetadata()
        {
            return new Metadata(UppdateradDatum.ToDateTime(), UppdateradAv, SkapadDatum.ToDateTime().Value, SkapadAv); // TODO: Överväg att bara använda nullable DateTime.
        }
    }
}
