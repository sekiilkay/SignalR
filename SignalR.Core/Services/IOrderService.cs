using SignalR.Core.DTOs.OrderDtos;

namespace SignalR.Core.Services
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllAsync();
        Task<GetByIdOrderDto> GetByIdAsync(int id);
        Task CreateAsync(CreateOrderDto request);
        Task UpdateAsync(UpdateOrderDto request);
        Task DeleteAsync(int id);

        Task<int> TotalOrderCountAsync();
        Task<int> ActiveOrderCountAsync();
        Task<decimal> LastOrderPriceAsync();
        decimal TodayTotalPrice();
    }
}
