using GeekShopping.ProductAPI.Data.DataObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
    {
        var products = await _repository.FindAll();
        return Ok(products);
    } 
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<ProductDto>> FindById(long id)
    {
        var product = await _repository.FindById(id);
        if (product is null) return NotFound();
        return Ok(product);
    } 
    
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto? dto)
    {
        if (dto is null)
            return BadRequest();

        var product = await _repository.Create(dto);
        return Ok(product);
    }
    
    [HttpPut]
    public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto? dto)
    {
        if (dto is null)
            return BadRequest();

        var product = await _repository.Update(dto);
        return Ok(product);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var status = await _repository.Delete(id);
        if (!status)
            return BadRequest();

        return Ok(status);
    }
    
}