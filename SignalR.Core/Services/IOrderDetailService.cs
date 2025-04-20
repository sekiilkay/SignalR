using SignalR.Core.DTOs.OrderDetailDtos;

namespace SignalR.Core.Services
{
    public interface IOrderDetailService
    {
        Task<List<ResultOrderDetailDto>> GetAllAsync();
        Task<GetByIdOrderDetailDto> GetByIdAsync(int id);
        Task CreateAsync(CreateOrderDetailDto request);
        Task UpdateAsync(UpdateOrderDetailDto request);
        Task DeleteAsync(int id);
    }
}
