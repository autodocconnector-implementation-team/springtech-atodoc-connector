namespace AutodocConnector.Application.Interfaces.ForPersistence.Repositories;

/// <summary>
/// GetStock repository declarition for persistence layer
/// </summary>
public interface IGetStockRepository
{
    /// <summary>
    /// Get product entity by articla number
    /// </summary>
    /// <param name="articleNumber">Springtech internal article number</param>
    /// <returns>Product entity</returns>
    Task<Product> GetProductByArticleNumberAsync(string articleNumber, string? priceCountry);

    /// <summary>
    /// Get product entity by EAN code
    /// </summary>
    /// <param name="ean">Ean code of product</param>
    /// <returns></returns>
    Task<Product> GetProductByEANAsync(string ean, string? priceCountry);
}
