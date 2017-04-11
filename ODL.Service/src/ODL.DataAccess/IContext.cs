using System.Data.Entity;

namespace ODL.DataAccess
{
    public interface IContext
    {
        DbSet<T> DbSet<T>() where T : class;
    }
}
