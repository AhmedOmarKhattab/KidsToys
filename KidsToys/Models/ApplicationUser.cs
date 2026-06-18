using Microsoft.AspNetCore.Identity;

namespace KidsToys.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAgree {  get; set; }

    }
}
