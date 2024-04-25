using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands.Delete
{


    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        public DeleteProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<DeleteProductCommandHandler> logger)
        {
            _writeUnitOfWork = writeUnitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product.Domain.Products.Product>(request);
            await _writeUnitOfWork.ProductWriteRepository.DeleteAsync(newProduct);
            _logger.LogInformation($"Product{newProduct.Id} is added");
            return true;
        }


    }
}
