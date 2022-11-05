using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace Test.Data.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum? Gender { get; set; }
    }
}