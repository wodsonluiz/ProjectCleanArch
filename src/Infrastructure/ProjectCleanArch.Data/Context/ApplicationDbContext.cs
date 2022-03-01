using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Category>().Property<string>("Name").HasMaxLength(100).IsRequired();
            builder.Entity<Category>().HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletronicos"),
                new Category(3, "Acessórios"));

            builder.Entity<Product>()
                .HasKey(x => x.Id);

            builder.Entity<Product>()
                .Property<string>("Name").HasMaxLength(100).IsRequired();

            builder.Entity<Product>().Property<string>("Description").HasMaxLength(200).IsRequired();
            builder.Entity<Product>().Property<decimal>("Price").HasPrecision(10, 2);
            builder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
