using AutoMapper;
using SignalR.Core.DTOs.CategoryDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;
using SignalR.Repository.Repositories;
using SignalR.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Service.Services
{
    public class CategoryService(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : ICategoryService
    {
        public async Task<int> ActiveCategoryCountAsync()
        {
            return await categoryRepository.ActiveCategoryCountAsync();
        }

        public async Task<int> CategoryCountAsync()
        {
            return await categoryRepository.CategoryCountAsync();
        }

        public void CategoryStatusChangeToFalse(int id)
        {
            categoryRepository.CategoryStatusChangeToFalse(id);
        }

        public void CategoryStatusChangeToTrue(int id)
        {
            categoryRepository.CategoryStatusChangeToTrue(id);
        }

        public async Task CreateAsync(CreateCategoryDto request)
        {
            var value = mapper.Map<Category>(request);
            await categoryRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await categoryRepository.GetByIdAsync(id);
            categoryRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var value = await categoryRepository.GetAllAsync();
            return mapper.Map<List<ResultCategoryDto>>(value);
        }

        public async Task<GetByIdCategoryDto> GetByIdAsync(int id)
        {
            var value = await categoryRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task<int> PassiveCategoryCountAsync()
        {
            return await categoryRepository.PassiveCategoryCountAsync();
        }

        public async Task UpdateAsync(UpdateCategoryDto request)
        {
            var value = mapper.Map<Category>(request);
            value.CategoryId = request.CategoryId;
            categoryRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
