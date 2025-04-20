using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class MenuTableRepository(SignalRContext context) : GenericRepository<MenuTable>(context), IMenuTableRepository
    {

        public void ChangeMenuTableStatusToFalse(int id)
        {
            var value = context.MenuTables
                .Where(x => x.MenuTableId == id)
                .FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            var value = context.MenuTables
                .Where(x => x.MenuTableId == id)
                .FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
        }

        public async Task<List<MenuTable>> GetMenuTableByStatusFalseAsync()
        {
            return await context.MenuTables
                .Where(x => x.Status == false)
                .ToListAsync();
        }

        public async Task<int> MenuTableCountAsync()
        {
            return await context.MenuTables
                .CountAsync();
        }
    }
}
