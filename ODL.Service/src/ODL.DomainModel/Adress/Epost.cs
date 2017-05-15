namespace ODL.DomainModel.Adress
{
    public class Epost
    {
        public Epost(string epostAdress)
        {
            EpostAdress = epostAdress;
        }

        public int AdressId { get; private set; }
        public string EpostAdress { get; internal set; }
        public virtual Adress Adress { get; set; }
    }
}
