using AutoMapper;
using GeekShopping.ProductAPI.Data.DataObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    public ProductRepository(MySqlContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private readonly MySqlContext _context;
    private readonly IMapper _mapper;
    
    public async Task<IEnumerable<ProductDto>> FindAll()
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto> FindById(long id)
    {
        var product = await _context.Products.FindAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public Task<ProductDto> Create(ProductDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> Update(ProductDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }
}