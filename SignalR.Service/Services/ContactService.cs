using AutoMapper;
using SignalR.Core.DTOs.ContactDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class ContactService(
        IContactRepository contactRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IContactService
    {
        public async Task CreateAsync(CreateContactDto request)
        {
            var value = mapper.Map<Contact>(request);
            await contactRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await contactRepository.GetByIdAsync(id);
            contactRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var value = await contactRepository.GetAllAsync();
            return mapper.Map<List<ResultContactDto>>(value);
        }

        public async Task<GetByIdContactDto> GetByIdAsync(int id)
        {
            var value = await contactRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdContactDto>(value);
        }

        public async Task UpdateAsync(UpdateContactDto request)
        {
            var value = mapper.Map<Contact>(request);
            value.ContactId = request.ContactId;
            contactRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
