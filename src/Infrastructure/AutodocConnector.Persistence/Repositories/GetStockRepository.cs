using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
using DbModels = AutodocConnector.Persistence.Models;
using DomainModels = AutodocConnector.Domain.Products.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AutodocConnector.Persistence.Repositories;

internal class GetStockRepository : IGetStockRepository
{
    private readonly DbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dbContext">Database context</param>
    /// <param name="mapper">Auto mapper</param>
    public GetStockRepository(DbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<DomainModels.Product?> GetProductByArticleNumber(string articleNumber, string? priceCountry)
    {
        //var product = await _dbContext.Products.ProjectTo<DomainModels.Product>(_mapper.ConfigurationProvider)
        //    .FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
        return new DomainModels.Product
        {
            Active = product.Active,
            ActivePrice = new DomainModels.ProductPrice { Price = 0 },
            ArticleNumber = product.ArticleNumber,
            CreatedAt = product.Created,
            Description = product.Description,
            Ean = product.Ean,
            Id = product.Id.ToString(),
            Name = product.Name,
            Stocks = product.Stocks,
        };
    }

    /// <inheritdoc/>
    public async Task<DomainModels.Product?> GetProductByEAN(string ean, string? priceCountry)
    {
        return await _dbContext.Products.ProjectTo<DomainModels.Product>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Ean == ean);
    }
}
