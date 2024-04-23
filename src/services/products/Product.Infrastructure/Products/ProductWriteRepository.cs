using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Products
{
    public class ProductWriteRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductWriteRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
