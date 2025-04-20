using SignalR.Core.DTOs.MenuTableDtos;

namespace SignalR.Core.Services
{
    public interface IMenuTableService
    {
        Task<List<ResultMenuTableDto>> GetAllAsync();
        Task<GetByIdMenuTableDto> GetByIdAsync(int id);
        Task CreateAsync(CreateMenuTableDto request);
        Task UpdateAsync(UpdateMenuTableDto request);
        Task DeleteAsync(int id);

        Task<int> MenuTableCountAsync();
        void ChangeMenuTableStatusToTrue(int id);
        void ChangeMenuTableStatusToFalse(int id);
        Task<List<ResultMenuTableDto>> GetMenuTableByStatusFalseAsync();
    }
}
