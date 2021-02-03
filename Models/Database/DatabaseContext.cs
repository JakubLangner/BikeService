using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.ViewModels.Service;

namespace BikeService.Models.Database
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<BikeService.ViewModels.Service.BikeViewModel> BikeViewModel { get; set; }

    }
}
