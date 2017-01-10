using Systemroll = ODL.DomainModel.Behorighet.Systemroll;

namespace ODL.DataAccess.Repositories.Behorighet
{
    public interface ISystemRepository
    {
        int SparaSystem(Systemroll.System system);
    }
}
