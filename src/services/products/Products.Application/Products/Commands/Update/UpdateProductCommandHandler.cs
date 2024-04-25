using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands.Update
{
    
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        public UpdateProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _writeUnitOfWork = writeUnitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct =    _mapper.Map<Product.Domain.Products.Product>(request);
            var addedProduct = await _writeUnitOfWork.ProductWriteRepository.UpdateAsync(newProduct);
            _logger.LogInformation($"Product{newProduct.Id} is added");
            return true;
        }

       
    }
}
