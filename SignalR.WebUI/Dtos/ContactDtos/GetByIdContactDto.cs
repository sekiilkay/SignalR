﻿namespace SignalR.WebUI.Dtos.ContactDtos
{
    public class GetByIdContactDto
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FooterTitle { get; set; }
        public string FooterDescription { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }
    }
}
