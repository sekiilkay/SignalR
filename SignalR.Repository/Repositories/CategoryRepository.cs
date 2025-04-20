using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class CategoryRepository(SignalRContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
        public async Task<int> ActiveCategoryCountAsync()
        {
            return await context.Categories
                .Where(x => x.Status == true)
                .CountAsync();
        }

        public async Task<int> CategoryCountAsync()
        {
            return await context.Categories
                .CountAsync();
        }

        public void CategoryStatusChangeToFalse(int id)
        {
            var value = context.Categories.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void CategoryStatusChangeToTrue(int id)
        {
            var value = context.Categories.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public async Task<int> PassiveCategoryCountAsync()
        {
            return await context.Categories
                .Where(x => x.Status == false)
                .CountAsync();
        }
    }
}
