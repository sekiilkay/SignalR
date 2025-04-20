using SignalR.Core.DTOs.DiscountDtos;
using SignalR.Core.Entities;

namespace SignalR.Core.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllAsync();
        Task<GetByIdDiscountDto> GetByIdAsync(int id);
        Task CreateAsync(CreateDiscountDto request);
        Task UpdateAsync(UpdateDiscountDto request);
        Task DeleteAsync(int id);

        void ChangeStatusToTrue(int id);
        void ChangeStatusToFalse(int id);
        Task<List<ResultDiscountDto>> GetListByStatusTrueAsync();
    }
}
