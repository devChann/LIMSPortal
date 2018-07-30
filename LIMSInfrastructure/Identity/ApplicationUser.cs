using Microsoft.AspNetCore.Identity;

namespace LIMSInfrastructure.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public IFormFile Photo { get; set; }
        public byte[] Photo { get; set; }
        public string KRAPIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string IDNumber { get; set; }

    }
}
