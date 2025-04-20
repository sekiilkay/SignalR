using SignalR.Core.DTOs.ProductDtos;
using SignalR.Core.Entities;

namespace SignalR.Core.Services
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task<GetByIdProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto request);
        Task UpdateAsync(UpdateProductDto request);
        Task DeleteAsync(int id);

        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoriesAsync();
        Task<int> ProductCountAsync();
        Task<int> ProductCountByCategoryNameHamburgerAsync();
        Task<int> ProductCountByCategoryNameDrinkAsync();
        Task<decimal> ProductPriceAvgAsync();
        Task<string> ProductNameByMaxPriceAsync();
        Task<string> ProductNameByMinPriceAsync();
        Task<decimal> ProductAvgPriceByHamburgerAsync();
        Task<decimal> ProductPriceBySteakBurgerAsync();
        Task<decimal> TotalPriceByDrinkCategoryAsync();
        Task<decimal> TotalPriceBySaladCategoryAsync();
        Task<decimal> TotalPriceByPizzaCategoryAsync();
        Task<decimal> TotalPriceByHamburgerCategoryAsync();
        Task<List<ResultProductDto>> GetLast9ProductsAsync();
        void ProductStatusChangeToTrue(int id);
        void ProductStatusChangeToFalse(int id);
    }
}
