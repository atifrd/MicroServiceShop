using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Product.Domain.Products;
using Products.Application.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands.Update
{

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IWriteUnitOfWork _writeUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        public UpdateProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger,
            IReadUnitOfWork readUnitOfWork)
        {
            _writeUnitOfWork = writeUnitOfWork;
            _mapper = mapper;
            _logger = logger;
            _readUnitOfWork = readUnitOfWork;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            

            var product = await _readUnitOfWork.ProductReadRepository.GetAsyncNoTracking(request.Id);
            if (product == null) { throw new NotFoundException("product", request.Id); }

            var newProduct = _mapper.Map<Product.Domain.Products.Product>(request);
            await _writeUnitOfWork.ProductWriteRepository.UpdateAsync(newProduct);
            _logger.LogInformation($"Product{product.Id} is updated");
            return true;
        }


    }
}
