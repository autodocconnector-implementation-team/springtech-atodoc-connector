namespace AutodocConnector.Persistence.Models;

internal class Product : MasterDataEntity
{
    /// <summary>
    /// Springtech article number
    /// </summary>
    public string ArticleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Name of product
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Detail product description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// EAN code of product
    /// </summary>
    public string Ean { get; set; } = string.Empty;

    /// <summary>
    /// Current stocks of this product
    /// </summary>
    public int Stocks { get; set; } = 0;
}
