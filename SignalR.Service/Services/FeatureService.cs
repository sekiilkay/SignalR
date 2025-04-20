using AutoMapper;
using SignalR.Core.DTOs.FeatureDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class FeatureService(
        IFeatureRepository featureRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IFeatureService
    {
        public async Task CreateAsync(CreateFeatureDto request)
        {
            var value = mapper.Map<Feature>(request);
            await featureRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await featureRepository.GetByIdAsync(id);
            featureRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            var value = await featureRepository.GetAllAsync();
            return mapper.Map<List<ResultFeatureDto>>(value);
        }

        public async Task<GetByIdFeatureDto> GetByIdAsync(int id)
        {
            var value = await featureRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdFeatureDto>(value);
        }

        public async Task UpdateAsync(UpdateFeatureDto request)
        {
            var value = mapper.Map<Feature>(request);
            value.FeatureId = request.FeatureId;
            featureRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
