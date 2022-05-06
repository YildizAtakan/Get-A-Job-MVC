using Microsoft.AspNet.Identity.EntityFramework;

namespace getajob.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}