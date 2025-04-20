using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<int> CategoryCountAsync();
        Task<int> ActiveCategoryCountAsync();
        Task<int> PassiveCategoryCountAsync();
        void CategoryStatusChangeToTrue(int id);
        void CategoryStatusChangeToFalse(int id);
    }
}
