﻿using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class ReadUnitOfWork : IReadUnitOfWork
    {
        public IProductReadRepository ProductReadRepository => throw new NotImplementedException();
    }
}
