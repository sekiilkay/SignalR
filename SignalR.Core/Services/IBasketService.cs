using SignalR.Core.DTOs.BasketDtos;
using SignalR.Core.Entities;

namespace SignalR.Core.Services
{
    public interface IBasketService
    {
        Task<List<ResultBasketDto>> GetAllAsync();
        Task<GetByIdBasketDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBasketDto request);
        Task UpdateAsync(UpdateBasketDto request);
        Task DeleteAsync(int id);

        Task<List<ResultBasketDto>> GetBasketByMenuTableNumberAsync(int id);
        Task<List<ResultBasketListWithProducts>> GetBasketByMenuTableWithProductNameAsync(int id);
        Task DeleteBasketByMenuTableIdAsync(int menuTableId);
    }
}
