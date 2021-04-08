using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class AplicationDbContext:DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products{get; set;}
        public DbSet<Category> Categories{get; set;}
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {
            }

        protected  override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category{ID=1, Name="Hair"},
                new Category{ID=2, Name="Makeup"},
                new Category{ID=3, Name="SkinCare"},
                new Category{ID=4, Name="Fragnance"}
            );

            builder.Entity<Product>().HasData(
                new Product{proID=1, proName ="Product Name 1",proDescription="Product Desscription",proPrice=50.00, Image="p1.webp", CategoryId=1},
                new Product{proID=2, proName ="Product Name 2",proDescription="Product Desscription",proPrice=50.00, Image="p3.webp", CategoryId=1},
                new Product{proID=3, proName ="Product Name 3",proDescription="Product Desscription",proPrice=50.00, Image="p4.webp", CategoryId=1},
                new Product{proID=4, proName ="Product Name 4",proDescription="Product Desscription",proPrice=50.00, Image="p5.webp", CategoryId=1},
                //
                new Product{proID=5, proName ="Product Name 6",proDescription="Product Desscription",proPrice=50.00, Image="p1.webp", CategoryId=2},
                new Product{proID=6, proName ="Product Name 7",proDescription="Product Desscription",proPrice=50.00, Image="p3.webp", CategoryId=2},
                new Product{proID=7, proName ="Product Name 8",proDescription="Product Desscription",proPrice=50.00, Image="p4.webp", CategoryId=2},
                new Product{proID=8, proName ="Product Name 9",proDescription="Product Desscription",proPrice=50.00, Image="p5.webp", CategoryId=2},
                //
                new Product{proID=9, proName ="Product Name 10",proDescription="Product Desscription",proPrice=50.00, Image="p1.webp", CategoryId=3},
                new Product{proID=10, proName ="Product Name 11",proDescription="Product Desscription",proPrice=50.00, Image="p3.webp", CategoryId=3},
                new Product{proID=11, proName ="Product Name 12",proDescription="Product Desscription",proPrice=50.00, Image="p4.webp", CategoryId=3},
                new Product{proID=12, proName ="Product Name 13",proDescription="Product Desscription",proPrice=50.00, Image="p5.webp", CategoryId=3},
                //
                new Product{proID=13, proName ="Product Name 14",proDescription="Product Desscription",proPrice=50.00, Image="p1.webp", CategoryId=4},
                new Product{proID=14, proName ="Product Name 15",proDescription="Product Desscription",proPrice=50.00, Image="p3.webp", CategoryId=4},
                new Product{proID=15, proName ="Product Name 16",proDescription="Product Desscription",proPrice=50.00, Image="p4.webp", CategoryId=4},
                new Product{proID=16, proName ="Product Name 17",proDescription="Product Desscription",proPrice=50.00, Image="p5.webp", CategoryId=4}
            );

        }
    }

}