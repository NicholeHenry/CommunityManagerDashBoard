using System;
using System.Collections.Generic;
using System.Text;
using CommunityManagerDashBoard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunityManagerDashBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Resident> Resident { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
