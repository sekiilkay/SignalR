using SignalR.Core.DTOs.SocialMediaDtos;

namespace SignalR.Core.Services
{
    public interface ISocialMediaService
    {
        Task<List<ResultSocialMediaDto>> GetAllAsync();
        Task<GetByIdSocialMediaDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSocialMediaDto request);
        Task UpdateAsync(UpdateSocialMediaDto request);
        Task DeleteAsync(int id);
    }
}
