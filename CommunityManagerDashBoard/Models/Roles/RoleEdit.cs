using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityManagerDashBoard.Models.Roles
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Memebers { get; set; }
        public IEnumerable<AppUser> NonMemebers { get; set;}

    }
}
