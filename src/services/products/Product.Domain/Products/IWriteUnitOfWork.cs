using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Products
{
    public interface IWriteUnitOfWork
    {
        IProductWriteRepository ProductWriteRepository { get; }
    }
}
