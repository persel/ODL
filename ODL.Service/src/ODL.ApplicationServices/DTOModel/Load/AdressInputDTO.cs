using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.ApplicationServices.DTOModel
{
    public abstract class AdressInputDTO : InputDTO
    {
        public string Adressvariant { get; set; }
        public GatuadressInputDTO GatuadressInput { get; set; }
        public EpostInputDTO EpostInput { get; set; }
        public TelefonInputDTO TelefonInput { get; set; }
    }
}