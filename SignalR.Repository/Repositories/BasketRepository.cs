using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class BasketRepository(SignalRContext context) : GenericRepository<Basket>(context), IBasketRepository
    {
        public async Task DeleteBasketByMenuTableIdAsync(int menuTableId)
        {
            var value = await context.MenuTables
                .Where(x => x.MenuTableId == menuTableId)
                .FirstOrDefaultAsync();
            context.MenuTables.Remove(value);
        }

        public async Task<List<Basket>> GetBasketByMenuTableNumberAsync(int id)
        {
            return await context.Baskets
                .Include(x => x.Product)
                .Where(x => x.MenuTableId == id)
                .ToListAsync();
        }

        public async Task<List<Basket>> GetBasketByMenuTableWithProductNameAsync(int id)
        {
            return await context.Baskets
                .Include(x => x.Product)
                .Where(x => x.MenuTableId == id)
                .ToListAsync();
        }
    }
}
