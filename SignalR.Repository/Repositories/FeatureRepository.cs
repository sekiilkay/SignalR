using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class FeatureRepository(SignalRContext context) : GenericRepository<Feature>(context), IFeatureRepository
    {
    }
}
