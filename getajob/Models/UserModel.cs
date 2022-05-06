using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using getajob.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace getajob.Models
{
    public class LoginModel
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }

    public class Register
    {
        [Required] public string Username { get; set; }

        [Required] public string ContactEmail { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string Name { get; set; }
    }

    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }

        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }

    public class RoleUpdateModel
    {
        [Required] public string RoleName { get; set; }

        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}