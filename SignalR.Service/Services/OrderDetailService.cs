using AutoMapper;
using SignalR.Core.DTOs.OrderDetailDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class OrderDetailService(
        IOrderDetailRepository orderDetailRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IOrderDetailService
    {
        public async Task CreateAsync(CreateOrderDetailDto request)
        {
            var value = mapper.Map<OrderDetail>(request);
            await orderDetailRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await orderDetailRepository.GetByIdAsync(id);
            orderDetailRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultOrderDetailDto>> GetAllAsync()
        {
            var value = await orderDetailRepository.GetAllAsync();
            return mapper.Map<List<ResultOrderDetailDto>>(value);
        }

        public async Task<GetByIdOrderDetailDto> GetByIdAsync(int id)
        {
            var value = await orderDetailRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdOrderDetailDto>(value);
        }

        public async Task UpdateAsync(UpdateOrderDetailDto request)
        {
            var value = mapper.Map<OrderDetail>(request);
            value.OrderDetailId = request.OrderDetailId;
            orderDetailRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
