using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class AboutRepository(SignalRContext context) : GenericRepository<About>(context), IAboutRepository
    {
    }
}
