using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Products.Application.Products.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductResDto>>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductListQueryHandler> _logger;
        public GetProductListQueryHandler(IMapper mapper, ILogger<GetProductListQueryHandler> logger,
           IReadUnitOfWork readUnitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _readUnitOfWork = readUnitOfWork;
        }

        public async Task<List<ProductResDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var res = await _readUnitOfWork.ProductReadRepository.GetAllAsync();
            return _mapper.Map<List<ProductResDto>>(res);
        }
    }
}
