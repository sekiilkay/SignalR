using SignalR.Core.DTOs.FeatureDtos;

namespace SignalR.Core.Services
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllAsync();
        Task<GetByIdFeatureDto> GetByIdAsync(int id);
        Task CreateAsync(CreateFeatureDto request);
        Task UpdateAsync(UpdateFeatureDto request);
        Task DeleteAsync(int id);
    }
}
