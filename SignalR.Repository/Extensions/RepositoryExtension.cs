using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalR.Core.Repositories;
using SignalR.Core.UnitOfWork;
using SignalR.Repository.Context;
using SignalR.Repository.Repositories;

namespace SignalR.Repository.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositoryExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IMenuTableRepository, MenuTableRepository>();
            services.AddScoped<IMoneyCaseRepository, MoneyCaseRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        } 
    }
}
