using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class MoneyCaseRepository(SignalRContext context) : GenericRepository<MoneyCase>(context), IMoneyCaseRepository
    {
        public async Task<decimal> TotalMoneyCaseAmountAsync()
        {
            return await context.MoneyCases
                .Select(x => x.TotalAmount)
                .FirstOrDefaultAsync();
        }
    }
}
