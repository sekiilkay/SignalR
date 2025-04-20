using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<int> TotalOrderCountAsync();
        Task<int> ActiveOrderCountAsync();
        Task<decimal> LastOrderPriceAsync();
        decimal TodayTotalPrice();
    }
}
