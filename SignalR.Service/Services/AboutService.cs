using AutoMapper;
using SignalR.Core.DTOs.AboutDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class AboutService(
        IAboutRepository aboutRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IAboutService
    {
        public async Task CreateAsync(CreateAboutDto request)
        {
            var value = mapper.Map<About>(request);
            await aboutRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await aboutRepository.GetByIdAsync(id);
            aboutRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var value = await aboutRepository.GetAllAsync();
            return mapper.Map<List<ResultAboutDto>>(value);
        }

        public async Task<GetByIdAboutDto> GetByIdAsync(int id)
        {
            var value = await aboutRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdAboutDto>(value);
        }

        public async Task UpdateAsync(UpdateAboutDto request)
        {
            var value = mapper.Map<About>(request);
            value.AboutId = request.AboutId;
            aboutRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
