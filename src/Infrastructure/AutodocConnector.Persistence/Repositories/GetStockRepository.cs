using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
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
        return await _dbContext.Products.ProjectTo<DomainModels.Product>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);
    }

    /// <inheritdoc/>
    public async Task<DomainModels.Product?> GetProductByEAN(string ean, string? priceCountry)
    {
        return await _dbContext.Products.ProjectTo<DomainModels.Product>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Ean == ean);
    }
}
