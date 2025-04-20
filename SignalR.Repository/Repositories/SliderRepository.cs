using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class SliderRepository(SignalRContext context) : GenericRepository<Slider>(context), ISliderRepository
    {
    }
}
