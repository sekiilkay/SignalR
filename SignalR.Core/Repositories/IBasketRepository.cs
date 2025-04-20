using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task<List<Basket>> GetBasketByMenuTableNumberAsync(int id);
        Task<List<Basket>> GetBasketByMenuTableWithProductNameAsync(int id);
        Task DeleteBasketByMenuTableIdAsync(int menuTableId);
    }
}
