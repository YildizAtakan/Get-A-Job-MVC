using System.Web.Mvc;
using getajob.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace getajob.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public UserManager<ApplicationUser> userManager;

        public AdminController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(userManager.Users);
        }
    }
}