﻿using Microsoft.AspNetCore.Http;

namespace GEM.Server.DTOs
{
    public class UserProfileUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public IFormFile? Image { get; set; } // Use IFormFile for file uploads
    }
}
