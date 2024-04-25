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

namespace Products.Application.Products.Commands.Delete
{


    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IWriteUnitOfWork _writeUnitOfWork;
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        public DeleteProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<DeleteProductCommandHandler> logger,
        IReadUnitOfWork readUnitOfWork
            )
        {
            _writeUnitOfWork = writeUnitOfWork;
            _mapper = mapper;
            _logger = logger;
            _readUnitOfWork = readUnitOfWork;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _readUnitOfWork.ProductReadRepository.GetAsync(request.Id);
            if (product == null) { throw new NotFoundException("product", request.Id); }
            await _writeUnitOfWork.ProductWriteRepository.DeleteAsync(product);
            _logger.LogInformation($"Product{product.Id} is added");
            return true;
        }


    }
}
