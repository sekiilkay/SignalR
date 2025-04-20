using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface IMenuTableRepository : IGenericRepository<MenuTable>
    {
        Task<int> MenuTableCountAsync();
        void ChangeMenuTableStatusToTrue(int id);
        void ChangeMenuTableStatusToFalse(int id);
        Task<List<MenuTable>> GetMenuTableByStatusFalseAsync();
    }
}
