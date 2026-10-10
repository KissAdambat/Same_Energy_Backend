using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
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
        public DbSet<UserM> Users { get; set; }
        public DbSet<OrderM>Orders { get; set; }
        public DbSet<OrderedItemM>Order_Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;password=;database=sameenergy");
        }
    }
}
