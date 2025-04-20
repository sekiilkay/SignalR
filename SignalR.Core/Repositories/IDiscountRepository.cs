using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        void ChangeStatusToTrue(int id);
        void ChangeStatusToFalse(int id);
        Task<List<Discount>> GetListByStatusTrueAsync();
    }
}
