﻿using Microsoft.AspNetCore.Identity;

namespace Database
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public AppUser(string username) : base(username)
        {

        }

        public AppUser()
        {

        }
    }
}
