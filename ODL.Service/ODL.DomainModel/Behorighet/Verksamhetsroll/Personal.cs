using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ODL.DomainModel.Behorighet.Verksamhetsroll
{

    [Table("Behorighet.Personal")]
    public partial class Personal
    {

        public Personal()
        {
            PersonalVerksamhetsroll = new HashSet<PersonalVerksamhetsroll>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Fornamn { get; set; }

        [Required]
        [StringLength(255)]
        public string Efternamn { get; set; }

        [Required]
        [StringLength(12)]
        public string Personnummer { get; set; }


        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalVerksamhetsroll> PersonalVerksamhetsroll { get; set; }

        [NotMapped]
        public bool IsNew => Id == 0;

    }
}
