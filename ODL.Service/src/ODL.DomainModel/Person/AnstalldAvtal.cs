using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODL.DomainModel.Person
{

    public partial class AnstalldAvtal
    {      
        public int AvtalId { get; set; }

        public int PersonId { get; set; }

        public virtual Person Anstalld { get; set; }

        public virtual Avtal Avtal { get; set; }

    }
}
