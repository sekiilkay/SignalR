using Microsoft.Extensions.DependencyInjection;
using SignalR.Core.Services;
using SignalR.Service.Mapping;
using SignalR.Service.Services;

namespace SignalR.Service.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AboutMapping));
            services.AddAutoMapper(typeof(BasketMapping));
            services.AddAutoMapper(typeof(BookingMapping));
            services.AddAutoMapper(typeof(CategoryMapping));
            services.AddAutoMapper(typeof(ContactMapping));
            services.AddAutoMapper(typeof(DiscountMapping));
            services.AddAutoMapper(typeof(MenuTableMapping));
            services.AddAutoMapper(typeof(MessageMapping));
            services.AddAutoMapper(typeof(MoneyCaseMapping));
            services.AddAutoMapper(typeof(NotificationMapping));
            services.AddAutoMapper(typeof(ProductMapping));
            services.AddAutoMapper(typeof(SliderMapping));
            services.AddAutoMapper(typeof(SocialMediaMapping));
            services.AddAutoMapper(typeof(TestimonialMapping));

            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IMenuTableService, MenuTableService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMoneyCaseService, MoneyCaseService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<ITestimonialService, TestimonialService>();

            return services;
        }
    }
}
