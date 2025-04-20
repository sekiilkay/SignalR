using AutoMapper;
using SignalR.Core.DTOs.SliderDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class SliderService(
        ISliderRepository sliderRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : ISliderService
    {
        public async Task CreateAsync(CreateSliderDto request)
        {
            var value = mapper.Map<Slider>(request);
            await sliderRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await sliderRepository.GetByIdAsync(id);
            sliderRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultSliderDto>> GetAllAsync()
        {
            var value = await sliderRepository.GetAllAsync();
            return mapper.Map<List<ResultSliderDto>>(value);
        }

        public async Task<GetByIdSliderDto> GetByIdAsync(int id)
        {
            var value = await sliderRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdSliderDto>(value);
        }

        public async Task UpdateAsync(UpdateSliderDto request)
        {
            var value = mapper.Map<Slider>(request);
            value.SliderId = request.SliderId;
            sliderRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
