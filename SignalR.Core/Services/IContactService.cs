using SignalR.Core.DTOs.ContactDtos;

namespace SignalR.Core.Services
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task<GetByIdContactDto> GetByIdAsync(int id);
        Task CreateAsync(CreateContactDto request);
        Task UpdateAsync(UpdateContactDto request);
        Task DeleteAsync(int id);
    }
}
