using SignalR.Core.DTOs.MoneyCaseDtos;

namespace SignalR.Core.Services
{
    public interface IMoneyCaseService
    {
        Task<List<ResultMoneyCaseDto>> GetAllAsync();
        Task<GetByIdMoneyCaseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateMoneyCaseDto request);
        Task UpdateAsync(UpdateMoneyCaseDto request);
        Task DeleteAsync(int id);

        Task<decimal> TotalMoneyCaseAmountAsync();
    }
}
