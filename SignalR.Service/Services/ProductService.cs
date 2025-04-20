using AutoMapper;
using SignalR.Core.DTOs.ProductDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;
using System.Linq.Expressions;

namespace SignalR.Service.Services
{
    public class ProductService(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IProductService
    {
        public async Task CreateAsync(CreateProductDto request)
        {
            var value = mapper.Map<Product>(request);
            await productRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await productRepository.GetByIdAsync(id);
            productRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var value = await productRepository.GetAllAsync();
            return mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task<GetByIdProductDto> GetByIdAsync(int id)
        {
            var value = await productRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductDto>> GetLast9ProductsAsync()
        {
            var value = await productRepository.GetLast9ProductsAsync();
            return mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoriesAsync()
        {
            var value = await productRepository.GetProductsWithCategoriesAsync();
            return mapper.Map<List<ResultProductWithCategoryDto>>(value);
        }

        public async Task<decimal> ProductAvgPriceByHamburgerAsync()
        {
            return await productRepository.ProductAvgPriceByHamburgerAsync();
        }

        public async Task<int> ProductCountAsync()
        {
            return await productRepository.ProductCountAsync();
        }

        public async Task<int> ProductCountByCategoryNameDrinkAsync()
        {
            return await productRepository.ProductCountByCategoryNameDrinkAsync();
        }

        public async Task<int> ProductCountByCategoryNameHamburgerAsync()
        {
            return await productRepository.ProductCountByCategoryNameHamburgerAsync();
        }

        public async Task<string> ProductNameByMaxPriceAsync()
        {
            return await productRepository.ProductNameByMaxPriceAsync();
        }

        public async Task<string> ProductNameByMinPriceAsync()
        {
            return await productRepository.ProductNameByMinPriceAsync();
        }

        public async Task<decimal> ProductPriceAvgAsync()
        {
            return await productRepository.ProductPriceAvgAsync();
        }

        public async Task<decimal> ProductPriceBySteakBurgerAsync()
        {
            return await productRepository.ProductPriceBySteakBurgerAsync();
        }

        public void ProductStatusChangeToFalse(int id)
        {
            productRepository.ProductStatusChangeToFalse(id);
        }

        public void ProductStatusChangeToTrue(int id)
        {
            productRepository.ProductStatusChangeToTrue(id);
        }

        public async Task<decimal> TotalPriceByDrinkCategoryAsync()
        {
            return await productRepository.TotalPriceByDrinkCategoryAsync();
        }

        public async Task<decimal> TotalPriceByHamburgerCategoryAsync()
        {
            return await productRepository.TotalPriceByHamburgerCategoryAsync();
        }

        public async Task<decimal> TotalPriceByPizzaCategoryAsync()
        {
            return await productRepository.TotalPriceByPizzaCategoryAsync();
        }

        public async Task<decimal> TotalPriceBySaladCategoryAsync()
        {
            return await productRepository.TotalPriceBySaladCategoryAsync();
        }

        public async Task UpdateAsync(UpdateProductDto request)
        {
            var value = mapper.Map<Product>(request);
            value.ProductId = request.ProductId;
            productRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
