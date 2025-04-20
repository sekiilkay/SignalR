using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class OrderDetailRepository(SignalRContext context) : GenericRepository<OrderDetail>(context), IOrderDetailRepository
    {
    }
}
