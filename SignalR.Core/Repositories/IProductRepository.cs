using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategoriesAsync();
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
        Task<List<Product>> GetLast9ProductsAsync();
        Task<decimal> ProductPriceAsync(int id);
        void ProductStatusChangeToTrue(int id);
        void ProductStatusChangeToFalse(int id);
    }
}
