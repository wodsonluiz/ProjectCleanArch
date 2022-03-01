using Microsoft.EntityFrameworkCore;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Data.EntityConfigurations
{
    public class ProductConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasKey(x => x.Id);

            builder.Entity<Product>()
                .Property<string>("Name").HasMaxLength(100).IsRequired();

            builder.Entity<Product>().Property<string>("Description").HasMaxLength(200).IsRequired();
            builder.Entity<Product>().Property<decimal>("Price").HasPrecision(10, 2);
        }
    }
}
