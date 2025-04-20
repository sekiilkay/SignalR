using SignalR.Core.DTOs.SliderDtos;

namespace SignalR.Core.Services
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllAsync();
        Task<GetByIdSliderDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSliderDto request);
        Task UpdateAsync(UpdateSliderDto request);
        Task DeleteAsync(int id);
    }
}
