using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.Products;
using MediatR;
using Products.Application.Products.Commands.Create;
using Products.Application.Products.Commands.Delete;
using Products.Application.Products.Commands.Update;
using Products.Application.Products.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IReadUnitOfWork _readUnitOfWork;
        //private readonly IMapper _mapper;
        //public ProductsController(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        //{
        //    _readUnitOfWork = readUnitOfWork;
        //    _mapper = mapper;
        //}

        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<ProductResDto>> Get()
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ProductResDto> Post(AddProductCommand request)
        {
            return await _mediator.Send(request);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, UpdateProductCommand request)
        {
            if (id != request.Id) { return BadRequest("id in body must be ewual id in query"); }
            var resp = await _mediator.Send(request);
            return resp;

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete]
        public async Task<bool> Delete(DeleteProductCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
