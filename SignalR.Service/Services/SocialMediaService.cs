using AutoMapper;
using SignalR.Core.DTOs.SocialMediaDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class SocialMediaService(
        ISocialMediaRepository socialMediaRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : ISocialMediaService
    {
        public async Task CreateAsync(CreateSocialMediaDto request)
        {
            var value = mapper.Map<SocialMedia>(request);
            await socialMediaRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await socialMediaRepository.GetByIdAsync(id);
            socialMediaRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultSocialMediaDto>> GetAllAsync()
        {
            var value = await socialMediaRepository.GetAllAsync();
            return mapper.Map<List<ResultSocialMediaDto>>(value);
        }

        public async Task<GetByIdSocialMediaDto> GetByIdAsync(int id)
        {
            var value = await socialMediaRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdSocialMediaDto>(value);
        }

        public async Task UpdateAsync(UpdateSocialMediaDto request)
        {
            var value = mapper.Map<SocialMedia>(request);
            value.SocialMediaId = request.SocialMediaId;
            socialMediaRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
