using AutoMapper;
using SignalR.Core.DTOs.TestimonialDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class TestimonialService(
        ITestimonialRepository testimonialRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : ITestimonialService
    {
        public async Task CreateAsync(CreateTestimonialDto request)
        {
            var value = mapper.Map<Testimonial>(request);
            await testimonialRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await testimonialRepository.GetByIdAsync(id);
            testimonialRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            var value = await testimonialRepository.GetAllAsync();
            return mapper.Map<List<ResultTestimonialDto>>(value);
        }

        public async Task<GetByIdTestimonialDto> GetByIdAsync(int id)
        {
            var value = await testimonialRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdTestimonialDto>(value);
        }

        public async Task UpdateAsync(UpdateTestimonialDto request)
        {
            var value = mapper.Map<Testimonial>(request);
            value.TestimonialId = request.TestimonialId;
            testimonialRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
