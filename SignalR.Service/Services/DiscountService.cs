using AutoMapper;
using SignalR.Core.DTOs.DiscountDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class DiscountService(
        IDiscountRepository discountRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IDiscountService
    {
        public void ChangeStatusToFalse(int id)
        {
            discountRepository.ChangeStatusToFalse(id);
        }

        public void ChangeStatusToTrue(int id)
        {
            discountRepository.ChangeStatusToTrue(id);
        }

        public async Task CreateAsync(CreateDiscountDto request)
        {
            var value = mapper.Map<Discount>(request);
            await discountRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await discountRepository.GetByIdAsync(id);
            discountRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultDiscountDto>> GetAllAsync()
        {
            var value = await discountRepository.GetAllAsync();
            return mapper.Map<List<ResultDiscountDto>>(value);
        }

        public async Task<GetByIdDiscountDto> GetByIdAsync(int id)
        {
            var value = await discountRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdDiscountDto>(value);
        }

        public async Task<List<ResultDiscountDto>> GetListByStatusTrueAsync()
        {
            var value = await discountRepository.GetListByStatusTrueAsync();
            return mapper.Map<List<ResultDiscountDto>>(value);
        }

        public async Task UpdateAsync(UpdateDiscountDto request)
        {
            var value = mapper.Map<Discount>(request);
            value.DiscountId = request.DiscountId;
            discountRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
