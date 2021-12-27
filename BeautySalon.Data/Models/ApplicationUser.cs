using Microsoft.AspNetCore.Identity;

namespace BeautySalon.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
