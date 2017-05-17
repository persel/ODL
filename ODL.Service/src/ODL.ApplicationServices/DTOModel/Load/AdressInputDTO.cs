using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.DTOModel
{
    public class AdressInputDTO : InputDTO
    {
        public string Personnummer { get; set; }
        public string KostnadsstalleNr { get; set; }

        public string Adressvariant { get; set; }
        public GatuadressInputDTO GatuadressInput { get; set; }
        public EpostInputDTO EpostInput { get; set; }
        public TelefonInputDTO TelefonInput { get; set; }

        public override string ToString()
        {
            return $", Adress av typen '{Adressvariant}' för " + (AvserPerson
                ? $"Personnummer: {Personnummer}"
                : $"Kostnadsställe: {KostnadsstalleNr}") ;
        }

        public bool AvserPerson => !string.IsNullOrWhiteSpace(Personnummer);

        public bool AvserResultatenhet => !string.IsNullOrWhiteSpace(KostnadsstalleNr);
    }
}