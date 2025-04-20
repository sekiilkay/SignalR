using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface IMoneyCaseRepository : IGenericRepository<MoneyCase>
    {
        Task<decimal> TotalMoneyCaseAmountAsync();
    }
}
