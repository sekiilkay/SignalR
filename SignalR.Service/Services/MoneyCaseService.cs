using AutoMapper;
using SignalR.Core.DTOs.MoneyCaseDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class MoneyCaseService(
        IMoneyCaseRepository moneyCaseRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IMoneyCaseService
    {
        public async Task CreateAsync(CreateMoneyCaseDto request)
        {
            var value = mapper.Map<MoneyCase>(request);
            await moneyCaseRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await moneyCaseRepository.GetByIdAsync(id);
            moneyCaseRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultMoneyCaseDto>> GetAllAsync()
        {
            var value = await moneyCaseRepository.GetAllAsync();
            return mapper.Map<List<ResultMoneyCaseDto>>(value);
        }

        public async Task<GetByIdMoneyCaseDto> GetByIdAsync(int id)
        {
            var value = await moneyCaseRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdMoneyCaseDto>(value);
        }

        public async Task<decimal> TotalMoneyCaseAmountAsync()
        {
            return await moneyCaseRepository.TotalMoneyCaseAmountAsync();
        }

        public async Task UpdateAsync(UpdateMoneyCaseDto request)
        {
            var value = mapper.Map<MoneyCase>(request);
            value.MoneyCaseId = request.MoneyCaseId;
            moneyCaseRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
