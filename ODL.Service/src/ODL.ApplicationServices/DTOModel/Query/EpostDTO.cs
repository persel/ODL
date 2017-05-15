using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class EpostDTO 
    {

        public static EpostDTO FromEpost(Epost epost)
        {
            if (epost == null)
                return null;

            var epostDTO = new EpostDTO();
            epostDTO.EpostAdress = epost.EpostAdress;

            return epostDTO;
        }


        public string EpostAdress { get; set; }
    }
}