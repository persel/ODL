
namespace ODL.DomainModel.Adress
{
    // TODO: Denna b�r refaktoreras till en Value Object - vi ska inte skapa nya poster i db vid persistering av Adress. 
    // TODO: Helst ocks� kontrollera instansieringen, jfr. AdressTyp, som dock �r en enum och har "fast antal" v�rden.
    public class AdressVariant
    {
        protected AdressVariant(){}

        public AdressVariant(string namn, AdressTyp adressTyp)
        {
            Namn = namn;
            AdressTyp = adressTyp;
        }
        public int Id { get; private set; }

        public string Namn { get; private set; }
        
        // Denna utg�r egen tabell i databasen, f�r att vi ska f� referensintegritet och "l�sbarhet" i db
        public AdressTyp AdressTyp { get; private set; } 
    }
}
