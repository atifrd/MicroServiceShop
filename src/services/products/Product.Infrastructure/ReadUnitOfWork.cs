using Product.Domain.Products;
using Product.Infrastructure.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class ReadUnitOfWork : IReadUnitOfWork
    {
        private ProductReadRepository _productReadRepository;
        private readonly ProductDbContext _dbContext;
        public ReadUnitOfWork(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IProductReadRepository ProductReadRepository
        {
            get { return _productReadRepository ?? new ProductReadRepository(_dbContext); }
        }
    }
}
