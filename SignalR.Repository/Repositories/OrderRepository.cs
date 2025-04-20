using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class OrderRepository(SignalRContext context) : GenericRepository<Order>(context), IOrderRepository
    {
        public async Task<int> ActiveOrderCountAsync()
        {
            return await context.Orders
                .Where(x => x.Description == "Müşteri Masada")
                .CountAsync();
        }

        public async Task<decimal> LastOrderPriceAsync()
        {
            return await context.Orders
                .OrderByDescending(x => x.OrderId)
                .Take(1)
                .Select(y => y.TotalPrice)
                .FirstOrDefaultAsync();
        }

        public decimal TodayTotalPrice()
        {
            return 0;
        }

        public async Task<int> TotalOrderCountAsync()
        {
            return await context.Orders
                .CountAsync();
        }
    }
}
