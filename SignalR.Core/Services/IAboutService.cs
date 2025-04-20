using SignalR.Core.DTOs.AboutDtos;

namespace SignalR.Core.Services
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task<GetByIdAboutDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAboutDto request);
        Task UpdateAsync(UpdateAboutDto request);
        Task DeleteAsync(int id);
    }
}
