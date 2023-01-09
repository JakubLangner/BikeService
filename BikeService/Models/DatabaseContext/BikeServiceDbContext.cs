using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Models.DatabaseContext
{
    public class BikeServiceDbContext : IdentityDbContext<AppUser>
    {
        public BikeServiceDbContext(DbContextOptions<BikeServiceDbContext> options) : base(options)
        {

        }
    }
}
