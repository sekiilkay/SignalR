﻿namespace SignalR.WebUI.Dtos.IdentityDtos
{
    public class UserEditDto
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
