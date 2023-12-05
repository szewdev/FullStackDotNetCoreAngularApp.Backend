using Backend.Application.Commands;
using Backend.Application.Commands.Interfaces;
using Backend.Application.DTOs;
using Backend.Application.Queries;
using Backend.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductCommandHandler commandHandler, IProductQueryHandler queryHandler) : ControllerBase
{
    private readonly IProductCommandHandler _commandHandler = commandHandler;
    private readonly IProductQueryHandler _queryHandler = queryHandler;

    // POST api/products
    [HttpPost]
    [SwaggerOperation(Summary = "Create new product")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var productId = await _commandHandler.Create(command);
        return CreatedAtAction(nameof(GetProduct), new { id = productId }, command);
    }

    // PUT api/products/{id}
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update existing product")]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _commandHandler.Update(command with { Id = id });
        return NoContent();
    }

    // GET api/products/{id}
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get product by ID")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var query = new GetProductQuery(id);
        var product = await _queryHandler.Handle(query);

        if (product == null) return NotFound();

        return product;
    }

    // GET api/products}
    [HttpGet]
    [SwaggerOperation(Summary = "Get all products")]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        var result = await _queryHandler.Handle();

        return result;
    }

    // DELETE api/products/{id}
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete product by ID")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _commandHandler.Delete(new DeleteProductCommand(id));
        return NoContent();
    }

    // PATCH api/products/{id}
    [HttpPatch("{id}")]
    [SwaggerOperation(Summary = "Restore deleted product by ID")]
    public async Task<ActionResult> RestoreProduct(int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _commandHandler.Restore(new RestoreProductCommand(id));
        return NoContent();
    }
}
