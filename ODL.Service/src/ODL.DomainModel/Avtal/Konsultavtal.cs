namespace ODL.DomainModel.Avtal
{
    public class KonsultAvtal
    {
        public int AvtalId { get; set; }

        public int PersonId { get; set; }

        public virtual Avtal Avtal { get; set; }
    }
}
