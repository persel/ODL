using System.Collections.Generic;

namespace ODL.DomainModel.Adress
{
  
    public partial class AdressVariant
    {
        
        public int Id { get; set; }

        public string Namn { get; set; }

        public virtual ICollection<Adress> Adress { get; set; }

        // Detta �r en tabell i databasen, f�r att vi ska f� referensintegritet och "l�sbarhet" i db
        public AdressTyp AdressTyp { get; set; } 
    }
}
