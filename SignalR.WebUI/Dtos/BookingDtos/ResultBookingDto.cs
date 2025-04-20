namespace SignalR.WebUI.Dtos.BookingDtos
{
    public class ResultBookingDto
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public string Description { get; set; }
    }
}
