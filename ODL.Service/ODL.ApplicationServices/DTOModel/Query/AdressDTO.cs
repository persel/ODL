using System.Collections.Generic;
using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class AdressDTO
    {
        public int Id { get; set; }
        public int AdressVariantFKId { get; set; }
        public virtual GatuAdress GatuAdress { get; set; }
        public virtual Mail Mail { get; set; }
        public virtual Telefon Telefon { get; set; }

    }
    
}