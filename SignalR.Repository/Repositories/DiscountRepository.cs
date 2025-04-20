using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class DiscountRepository(SignalRContext context) : GenericRepository<Discount>(context), IDiscountRepository
    {
        public void ChangeStatusToFalse(int id)
        {
            var value = context.Discounts.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var value = context.Discounts.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public async Task<List<Discount>> GetListByStatusTrueAsync()
        {
            return await context.Discounts
                .Where(x => x.Status == true)
                .ToListAsync();
        }
    }
}
