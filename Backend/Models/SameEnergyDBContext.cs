using Microsoft.EntityFrameworkCore;
namespace Backend.Models
{
    public class SameEnergyDBContext : DbContext
    {
        public SameEnergyDBContext(DbContextOptions<SameEnergyDBContext> options) : base(options)
        {
        }
        public SameEnergyDBContext()
        {
        }
        public DbSet<ProductM> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;password=;database=sameenergy");
        }
    }
}
