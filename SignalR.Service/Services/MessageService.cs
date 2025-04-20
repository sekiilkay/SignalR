using AutoMapper;
using SignalR.Core.DTOs.MessageDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class MessageService(
        IMessageRepository messageRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IMessageService
    {
        public async Task CreateAsync(CreateMessageDto request)
        {
            var value = mapper.Map<Message>(request);
            value.Status = false;
            value.MessageSendDate = DateTime.Now;
            await messageRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await messageRepository.GetByIdAsync(id);
            messageRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllAsync()
        {
            var value = await messageRepository.GetAllAsync();
            return mapper.Map<List<ResultMessageDto>>(value);
        }

        public async Task<GetByIdMessageDto> GetByIdAsync(int id)
        {
            var value = await messageRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task UpdateAsync(UpdateMessageDto request)
        {
            var value = mapper.Map<Message>(request);
            value.MessageId = request.MessageId;
            messageRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
