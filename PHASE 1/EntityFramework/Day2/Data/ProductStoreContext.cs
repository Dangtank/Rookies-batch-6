using Microsoft.EntityFrameworkCore;
using Day2.Models;

namespace Day2.Data

{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                            .ToTable("Category")//ten bang trong sql
                            .HasKey(cat => cat.CategoryId);//khoa chinh

            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(pro => pro.ProductId);

            modelBuilder.Entity<Product>()                        
                            .HasOne<Category>(s => s.Category)//lay 1 category trong product
                            .WithMany(g => g.Products)//1 category nay ket noi nhieu product
                            .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.ProductId)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.ProductName)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.Manufacture)
                            .HasColumnName("Manufacture")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int");
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}