using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ODL.DomainModel.Behorighet.Verksamhetsroll;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{

    [Table("Person.Person")]
    public partial class Person
    {

        public Person()
        {
            AnstallningsAvtal = new HashSet<AnstalldAvtal>();
            KonsultAvtal = new HashSet<KonsultAvtal>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string KallsystemId { get; set; }

        [Required]
        [StringLength(255)]
        public string Fornamn { get; set; }

        [StringLength(255)]
        public string Mellannamn { get; set; }

        [Required]
        [StringLength(255)]
        public string Efternamn { get; set; }

        [Required]
        [StringLength(12)]
        public string Personnummer { get; set; }

        public Metadata Metadata { get; set; }


        // TODO: Person har listor av konsultavtal och anställningsavtal - Praktiskt men inte helt optimalt eftersom Avtal har samma referenser (genom 1:1-relationer) och 
        // man därigenom kan uppdatera samma tabeller via två olika aggregat (Person och Avtal), vilket kan ge concurrency issues etc. Vore bra om Person inte hade konsultavtal och anställningsavtal,
        // vilket dock ger mer logik i Servicen, utanför modellen.

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnstalldAvtal> AnstallningsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AnstallningsAvtalIdn => AnstallningsAvtal.Select(anstallningsAvtal => anstallningsAvtal.Avtal.Id);

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonsultAvtal> KonsultAvtal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonVerksamhetsroll> Verksamhetsroller { get; set; }

        [NotMapped]
        public IEnumerable<int> KonsultAvtalIdn => KonsultAvtal.Select(konsultAvtal => konsultAvtal.Avtal.Id);

        [NotMapped]
        public bool IsNew => Id == 0;

        public bool IsAnstalld()
        {
            return AnstallningsAvtal.Any();
        }

        public bool IsKonsult()
        {
            return KonsultAvtal.Any();
        }

        public IEnumerable<int> AllaAvtalIdn()
        {
            if (IsAnstalld() && IsKonsult())
                return AnstallningsAvtalIdn.Concat(KonsultAvtalIdn);
            return IsAnstalld()
                ? AnstallningsAvtalIdn
                : (IsKonsult() ? KonsultAvtalIdn : new List<int>()); // Tar hänsyn till om en person är varken konsult eller anställd...
        }

        /// <summary>
        /// Personen är kopplad till organisationen genom minst ett avtal 
        /// </summary>
        public bool KoppladTill(Organisation.Organisation organisation)
        {
            return AllaAvtalIdn().Intersect(organisation.AllaAvtalIdn).Any();
        }

    }
}
