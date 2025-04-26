using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpApp.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Stock).IsRequired();

            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);


            builder.HasData(
                new Product(1, "Caneta Bic", "Cor da caneta: azul", 3.50m, 200, "canetabic.jpg")
                { CategoryId = 1 },

                new Product(2, "Celular Motorola", "Celular moto g com 256gb de armazenamento", 850.00m, 100, "celularmotog.jpg")
                { CategoryId = 2 },

                new Product(3, "Shorts Jeans Feminino", "Shorts preto da marca monnari", 125.00m, 50, "shortsmonnari.jpg")
                { CategoryId = 3 },

                new Product(4, "Martelo", "Martelo pequeno", 70.00m, 350, "martelopequeno.jpg")
                { CategoryId = 4 }

                );

        }

    }
}
