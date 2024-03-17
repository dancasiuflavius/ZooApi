using Microsoft.EntityFrameworkCore;
using ZooCrudApi.Animals.Model;

namespace ZooCrudApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Animal> Animals { get; set; }
    }
}
