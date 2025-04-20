using SignalR.Core.DTOs.MessageDtos;

namespace SignalR.Core.Services
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllAsync();
        Task<GetByIdMessageDto> GetByIdAsync(int id);
        Task CreateAsync(CreateMessageDto request);
        Task UpdateAsync(UpdateMessageDto request);
        Task DeleteAsync(int id);
    }
}
