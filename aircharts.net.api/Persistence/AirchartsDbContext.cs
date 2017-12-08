using aircharts.net.api.Models;
using Microsoft.EntityFrameworkCore;

namespace aircharts.net.api.Persistence
{
    public class AcDbContext : DbContext
    {
        public AcDbContext(DbContextOptions<AcDbContext> options)
            : base(options)
        {
        }

        public DbSet<Chart> Charts { get; set; }
    }
}
