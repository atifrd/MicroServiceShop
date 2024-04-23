using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class WriteUnitOfWork : IWriteUnitOfWork
    {
        IProductWriteRepository IWriteUnitOfWork.ProductWriteRepository => throw new NotImplementedException();
    }
}
