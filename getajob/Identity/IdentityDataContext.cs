using Microsoft.AspNet.Identity.EntityFramework;

namespace getajob.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("identityConnection")
        {
        }
    }
}