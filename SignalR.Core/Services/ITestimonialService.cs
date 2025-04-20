using SignalR.Core.DTOs.TestimonialDtos;

namespace SignalR.Core.Services
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllAsync();
        Task<GetByIdTestimonialDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTestimonialDto request);
        Task UpdateAsync(UpdateTestimonialDto request);
        Task DeleteAsync(int id);
    }
}
