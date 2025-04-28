using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var unused = modelbuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Produto 1", Description = "Descrição do produto 1" },
                new Product { Id = 2, Name = "Produto 2", Description = "Descrição do Produto 2" }
                );

        }

    }
}
