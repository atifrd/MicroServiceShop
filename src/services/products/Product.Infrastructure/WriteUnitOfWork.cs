using Product.Domain.Products;
using Product.Infrastructure.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class WriteUnitOfWork : IWriteUnitOfWork
    {
        private ProductWriteRepository _productWriteRepository;
        private readonly ProductDbContext _dbContext;
        public WriteUnitOfWork(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public IProductWriteRepository ProductWriteRepository
        {
            get { return _productWriteRepository ?? new ProductWriteRepository(_dbContext); }
        }
    }
}
