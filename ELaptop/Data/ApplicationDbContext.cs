using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELaptop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
             
    }
        public DbSet<ELaptop.Models.RoleModel> RoleModel { get; set; }
       public DbSet<ModelLayer.LaptopModel> LaptopModel { get; set; }
    }
}
