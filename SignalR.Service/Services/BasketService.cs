using AutoMapper;
using SignalR.Core.DTOs.BasketDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class BasketService(
        IBasketRepository basketRepository,
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IBasketService
    {
        public async Task CreateAsync(CreateBasketDto request)
        {
            var value = mapper.Map<Basket>(request);
            value.Count = 1;
            value.Price = await productRepository.ProductPriceAsync(request.ProductId);
            value.TotalPrice = value.Count * value.Price;
            await basketRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await basketRepository.GetByIdAsync(id);
            basketRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBasketByMenuTableIdAsync(int menuTableId)
        {
            await basketRepository.DeleteBasketByMenuTableIdAsync(menuTableId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultBasketDto>> GetAllAsync()
        {
            var value = await basketRepository.GetAllAsync();
            return mapper.Map<List<ResultBasketDto>>(value);
        }

        public async Task<List<ResultBasketDto>> GetBasketByMenuTableNumberAsync(int id)
        {
            var value = await basketRepository.GetBasketByMenuTableNumberAsync(id);
            return mapper.Map<List<ResultBasketDto>>(value);
        }

        public async Task<List<ResultBasketListWithProducts>> GetBasketByMenuTableWithProductNameAsync(int id)
        {
            var value = await basketRepository.GetBasketByMenuTableWithProductNameAsync(id);
            return mapper.Map<List<ResultBasketListWithProducts>>(value);
        }

        public async Task<GetByIdBasketDto> GetByIdAsync(int id)
        {
            var value = await basketRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdBasketDto>(value);
        }

        public async Task UpdateAsync(UpdateBasketDto request)
        {
            var value = mapper.Map<Basket>(request);
            value.BasketId = request.BasketId;
            basketRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
