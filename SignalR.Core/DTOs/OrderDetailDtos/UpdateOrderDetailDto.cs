namespace SignalR.Core.DTOs.OrderDetailDtos
{
    public class UpdateOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
