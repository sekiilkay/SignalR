using AutoMapper;
using SignalR.Core.DTOs.MenuTableDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;
using System.Reflection.Metadata.Ecma335;

namespace SignalR.Service.Services
{
    public class MenuTableService(
        IMenuTableRepository menuTableRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IMenuTableService
    {
        public void ChangeMenuTableStatusToFalse(int id)
        {
            menuTableRepository.ChangeMenuTableStatusToFalse(id);
        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
            menuTableRepository.ChangeMenuTableStatusToTrue(id);
        }

        public async Task CreateAsync(CreateMenuTableDto request)
        {
            var value = mapper.Map<MenuTable>(request);
            value.Status = false;
            await menuTableRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await menuTableRepository.GetByIdAsync(id);
            menuTableRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultMenuTableDto>> GetAllAsync()
        {
            var value = await menuTableRepository.GetAllAsync();
            return mapper.Map<List<ResultMenuTableDto>>(value);
        }

        public async Task<GetByIdMenuTableDto> GetByIdAsync(int id)
        {
            var value = await menuTableRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdMenuTableDto>(value);
        }

        public async Task<List<ResultMenuTableDto>> GetMenuTableByStatusFalseAsync()
        {
            var value = await menuTableRepository.GetMenuTableByStatusFalseAsync();
            return mapper.Map<List<ResultMenuTableDto>>(value);
        }

        public async Task<int> MenuTableCountAsync()
        {
            return await menuTableRepository.MenuTableCountAsync();
        }

        public async Task UpdateAsync(UpdateMenuTableDto request)
        {
            var value = mapper.Map<MenuTable>(request);
            value.MenuTableId = request.MenuTableId;
            menuTableRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
