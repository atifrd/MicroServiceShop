using MediatR;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Products.Queries
{
    public class GetProductListQuery : IRequest<List<ProductResDto>>
    {
    }
}
