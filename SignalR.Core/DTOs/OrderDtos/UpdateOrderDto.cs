namespace SignalR.Core.DTOs.OrderDtos
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
