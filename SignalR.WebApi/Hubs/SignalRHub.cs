using Microsoft.AspNetCore.SignalR;
using SignalR.Core.Services;

namespace SignalR.WebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
        {
            var value = await _categoryService.CategoryCountAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = await _productService.ProductCountAsync();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = await _categoryService.ActiveCategoryCountAsync();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = await _categoryService.PassiveCategoryCountAsync();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = await _productService.ProductCountByCategoryNameHamburgerAsync();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6 = await _productService.ProductCountByCategoryNameDrinkAsync();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

            var value7 = await _productService.ProductPriceAvgAsync();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00") + "₺");

            var value8 = await _productService.ProductNameByMaxPriceAsync();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

            var value9 = await _productService.ProductNameByMinPriceAsync();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

            var value10 = await _productService.ProductAvgPriceByHamburgerAsync();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

            var value14 = await _moneyCaseService.TotalMoneyCaseAmountAsync();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

            var value16 = await _menuTableService.MenuTableCountAsync();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
        }
        public async Task SendProgress()
        {
            var value = await _moneyCaseService.TotalMoneyCaseAmountAsync();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value2 = await _productService.ProductCountAsync();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = await _categoryService.CategoryCountAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", value3);

            var value5 = await _menuTableService.MenuTableCountAsync();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value5);

            var value6 = await _bookingService.BookingCountAsync();
            await Clients.All.SendAsync("ReceiveBookingCount", value6);

            var value7 = await _productService.ProductPriceAvgAsync();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7);

            var value8 = await _notificationService.NotificationCountByStatusFalseAsync();
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", value8);

            var value9 = await _productService.ProductCountByCategoryNameDrinkAsync();
            await Clients.All.SendAsync("ReceiveDrinkCount", value9);

            var value10 = await _productService.ProductCountByCategoryNameHamburgerAsync();
            await Clients.All.SendAsync("ReceiveHamburgerCount", value10);

            var value11 = await _productService.TotalPriceBySaladCategoryAsync();
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", value11.ToString("0.00") + "₺");

            var value12 = await _productService.TotalPriceByHamburgerCategoryAsync();
            await Clients.All.SendAsync("ReceiveTotalPriceByHamburgerCategory", value12.ToString("0.00") + "₺");

            var value13 = await _productService.TotalPriceByDrinkCategoryAsync();
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", value13.ToString("0.00") + "₺");

            var value14 = await _productService.TotalPriceByPizzaCategoryAsync();
            await Clients.All.SendAsync("ReceiveTotalPriceByPizzaCategory", value14.ToString("0.00") + "₺");
        }
        public async Task GetBookingList()
        {
            var values = await _bookingService.GetAllAsync();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }
        public async Task SendNotification()
        {
            var value = await _notificationService.NotificationCountByStatusFalseAsync();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificationListByFalse = await _notificationService.GetAllNotificationByFalseAsync();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
        }
        public async Task GetMenuTableStatus()
        {
            var value = await _menuTableService.GetAllAsync();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
