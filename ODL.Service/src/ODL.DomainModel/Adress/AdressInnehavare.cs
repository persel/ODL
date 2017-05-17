
namespace ODL.DomainModel.Adress
{
    public abstract class Adressinnehavare
    {
        public abstract int Id { get; set; }

        public bool IsPerson => Is<Person.Person>();
        public bool IsOrganisation => Is<Organisation.Organisation>();

        private bool Is<T>() where T : Adressinnehavare
        {
            return GetType() == typeof(T);
        }
    }
}
