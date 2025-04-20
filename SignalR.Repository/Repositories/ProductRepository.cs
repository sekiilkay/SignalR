using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class ProductRepository(SignalRContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task<List<Product>> GetLast9ProductsAsync()
        {
            return await context.Products
                .Take(9)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsWithCategoriesAsync()
        {
            return await context.Products
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<decimal> ProductAvgPriceByHamburgerAsync()
        {
            return await Context.Products
                .Where(x => x.CategoryId == (context.Categories.Where(y => y.Name == "Hamburger")
                .Select(z => z.CategoryId)
                .FirstOrDefault()))
                .AverageAsync(w => w.Price);
        }

        public async Task<int> ProductCountAsync()
        {
            return await context.Products
                .CountAsync();
        }

        public async Task<int> ProductCountByCategoryNameDrinkAsync()
        {
            return await context.Products
                .Where(x => x.CategoryId == (Context.Categories.Where(y => y.Name == "İçecek")
                .Select(z => z.CategoryId)
                .FirstOrDefault()))
                .CountAsync();
        }

        public async Task<int> ProductCountByCategoryNameHamburgerAsync()
        {
            return await context.Products
                .Where(x => x.CategoryId == (Context.Categories.Where(y => y.Name == "Hamburger")
                .Select(z => z.CategoryId)
                .FirstOrDefault()))
                .CountAsync();
        }

        public async Task<string> ProductNameByMaxPriceAsync()
        {
            return (await context.Products
                .Where(x => x.Price == (context.Products.Max(y => y.Price)))
                .Select(z => z.Name)
                .FirstOrDefaultAsync())!;
        }

        public async Task<string> ProductNameByMinPriceAsync()
        {
            return (await context.Products
                .Where(x => x.Price == (context.Products.Min(y => y.Price)))
                .Select(z => z.Name)
                .FirstOrDefaultAsync())!;
        }

        public async Task<decimal> ProductPriceAsync(int id)
        {
            return await context.Products
                .Where(x => x.ProductId == id)
                .Select(y => y.Price)
                .FirstOrDefaultAsync();
        }

        public async Task<decimal> ProductPriceAvgAsync()
        {
            return await context.Products
                .AverageAsync(x => x.Price);
        }

        public async Task<decimal> ProductPriceBySteakBurgerAsync()
        {
            return await context.Products
                .Where(x => x.Name == "Steak Burger")
                .Select(y => y.Price)
                .FirstOrDefaultAsync();
        }

        public void ProductStatusChangeToFalse(int id)
        {
            var value = context.Products.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void ProductStatusChangeToTrue(int id)
        {
            var value = context.Products.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public async Task<decimal> TotalPriceByDrinkCategoryAsync()
        {
            return await context.Products
                .Where(t => t.CategoryId == context.Categories
                .Where(x => x.Name == "İçecek")
                .Select(y => y.CategoryId)
                .FirstOrDefault())
                .SumAsync(e => e.Price);
        }

        public async Task<decimal> TotalPriceByHamburgerCategoryAsync()
        {
            return await context.Products
                .Where(t => t.CategoryId == context.Categories
                .Where(x => x.Name == "Hamburger")
                .Select(y => y.CategoryId)
                .FirstOrDefault())
                .SumAsync(e => e.Price);
        }

        public async Task<decimal> TotalPriceByPizzaCategoryAsync()
        {
            return await context.Products
                .Where(t => t.CategoryId == context.Categories
                .Where(x => x.Name == "Pizza")
                .Select(y => y.CategoryId)
                .FirstOrDefault())
                .SumAsync(e => e.Price);
        }

        public async Task<decimal> TotalPriceBySaladCategoryAsync()
        {
            return await context.Products
                .Where(t => t.CategoryId == context.Categories
                .Where(x => x.Name == "Salata")
                .Select(y => y.CategoryId)
                .FirstOrDefault())
                .SumAsync(e => e.Price);
        }
    }
}
