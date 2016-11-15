namespace ODL.DomainModel.Person
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person.KonsultAvtal")]
    public partial class KonsultAvtal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonFKId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvtalFKId { get; set; }

        public virtual Konsult Konsult { get; set; }
    }
}
