using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UnitOfWorkEx.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public IConfiguration Configuration { get; private set; }

        public DatabaseContext(IConfiguration configuration)
        : base()
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnectionString"];

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                 .HasData(new Product
                 {
                     Id = 1,
                     ProductName = "Product1",
                     ProductCategory = "Category1",
                     ProductPrice = 10
                 });
        }
    }
}