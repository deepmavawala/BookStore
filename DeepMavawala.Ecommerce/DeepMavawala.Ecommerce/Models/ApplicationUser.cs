﻿using Microsoft.AspNetCore.Identity;

namespace DeepMavawala.Ecommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserNameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
    }
}
