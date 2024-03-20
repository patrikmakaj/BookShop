using BookShop.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new
            {
                Id = 1, Name = "SciFi", DisplayOrder = 1
            },
            new
            {
                Id = 2, Name = "Novel", DisplayOrder = 2
            },
            new
            {
                Id = 3, Name = "Thriller", DisplayOrder = 3
            }

            );

       modelBuilder.Entity<Product>().HasData(

            new
            {
                Id = 1,
                Title = "Knjiga",
                Description = "Ovo je primjer knjige",
                ISBN = "AB25",
                Author = "Patrik Ocelic",
                ListPrice = 50.0,
                Price = 50.0,
                Price50 = 40.0,
                Price100 = 25.0,
                CategoryId = 1,
                ImageUrl = "slika.jpg"
            });
    }

}
