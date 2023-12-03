using Backend.Application.Commands;
using Backend.Application.Commands.Interfaces;
using Backend.Application.DTOs;
using Backend.Application.Queries;
using Backend.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductCommandHandler commandHandler, IProductQueryHandler queryHandler) : ControllerBase
{
    private readonly IProductCommandHandler _commandHandler = commandHandler;
    private readonly IProductQueryHandler _queryHandler = queryHandler;

    // POST api/products
    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var productId = await _commandHandler.Handle(command);
        return CreatedAtAction(nameof(GetProduct), new { id = productId }, command);
    }

    // PUT api/products/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _commandHandler.Handle(command with { Id = id });
        return NoContent();
    }

    // GET api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var query = new GetProductQuery(id);
        var product = await _queryHandler.Handle(query);

        if (product == null) return NotFound();

        return product;
    }

    // GET api/products}
    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        var result = await _queryHandler.Handle();

        return result;
    }
}
