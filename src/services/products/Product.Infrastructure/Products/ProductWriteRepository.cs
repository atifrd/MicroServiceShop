using productModel =Product.Domain.Products ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Domain.Products;

namespace Product.Infrastructure.Products
{
   
        public class ProductWriteRepository : IProductWriteRepository
        {

            private readonly ProductDbContext _dbContext;
            public ProductWriteRepository(ProductDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Product.Domain.Products.Product> AddAsync(productModel.Product product)
            {
                var productEntry = await _dbContext.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return productEntry.Entity;
            }

            public async Task<productModel.Product> UpdateAsync(productModel.Product product)
            {
                var productEntry = _dbContext.Update(product);


                await _dbContext.SaveChangesAsync();
                return product;
            }

            public async Task DeleteAsync(productModel.Product product)
            {

                _dbContext.Products.Remove(product);

                await _dbContext.SaveChangesAsync();
            }

        }
    }