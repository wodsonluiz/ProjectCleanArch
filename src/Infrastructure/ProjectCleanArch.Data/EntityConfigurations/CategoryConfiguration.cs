using Microsoft.EntityFrameworkCore;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Data.EntityConfigurations
{
    public class CategoryConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Category>().Property<string>("Name").HasMaxLength(100).IsRequired();
            builder.Entity<Category>().HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletronicos"),
                new Category(3, "Acessórios"));
        }
    }
}
