using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class SocialMediaRepository(SignalRContext context) : GenericRepository<SocialMedia>(context), ISocialMediaRepository
    {
    }
}
