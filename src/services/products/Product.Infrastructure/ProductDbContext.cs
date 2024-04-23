using Microsoft.EntityFrameworkCore;
using Product.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)  //option ro be class pedar pas dad
        {

        }
        public DbSet<Product.Domain.Products.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Product.Domain.Products.Product.ProductConfiguration());
            modelBuilder.ApplyConfiguration(new Category.CategoryConfiguration());
        }

    }
}
