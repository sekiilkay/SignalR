using AutoMapper;
using SignalR.Core.DTOs.OrderDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class OrderService(
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IOrderService
    {
        public async Task<int> ActiveOrderCountAsync()
        {
            return await orderRepository.ActiveOrderCountAsync();
        }

        public async Task CreateAsync(CreateOrderDto request)
        {
            var value = mapper.Map<Order>(request);
            value.Description = "Müşteri Masada";
            await orderRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await orderRepository.GetByIdAsync(id);
            orderRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultOrderDto>> GetAllAsync()
        {
            var value = await orderRepository.GetAllAsync();
            return mapper.Map<List<ResultOrderDto>>(value);
        }

        public async Task<GetByIdOrderDto> GetByIdAsync(int id)
        {
            var value = await orderRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdOrderDto>(value);
        }

        public async Task<decimal> LastOrderPriceAsync()
        {
            return await orderRepository.LastOrderPriceAsync();
        }

        public decimal TodayTotalPrice()
        {
            return orderRepository.TodayTotalPrice();
        }

        public async Task<int> TotalOrderCountAsync()
        {
            return await orderRepository.TotalOrderCountAsync();
        }

        public async Task UpdateAsync(UpdateOrderDto request)
        {
            var value = mapper.Map<Order>(request);
            value.OrderId = request.OrderId;
            value.Description = "Sipariş Tamamlandı";
            orderRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
