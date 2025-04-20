using SignalR.Core.DTOs.CategoryDtos;

namespace SignalR.Core.Services
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<GetByIdCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto request);
        Task UpdateAsync(UpdateCategoryDto request);
        Task DeleteAsync(int id);

        Task<int> CategoryCountAsync();
        Task<int> ActiveCategoryCountAsync();
        Task<int> PassiveCategoryCountAsync();
        void CategoryStatusChangeToTrue(int id);
        void CategoryStatusChangeToFalse(int id);
    }
}
