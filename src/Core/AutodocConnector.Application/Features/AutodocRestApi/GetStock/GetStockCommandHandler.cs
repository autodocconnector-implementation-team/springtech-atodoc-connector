using AutodocConnector.Application.Interfaces.ForPresentation;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock;

/// <summary>
/// Get stock request command handler
/// </summary>
public class GetStockCommandHandler : IRequestHandler<GetStockRequest, GetStockResponse>
{
    private readonly GetStockValidator _validator;
    private readonly IGetStockRepository _repository;
    private readonly IAuthenticatedAutodocUser _authenticatedUser;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="validator">Request validator service</param>
    /// <param name="repository">Repository service</param>
    /// <param name="authenticatedUser">Athanticated user provider</param>
    public GetStockCommandHandler(GetStockValidator validator, IGetStockRepository repository, IAuthenticatedAutodocUser authenticatedUser)
    {
        _validator = validator;
        _repository = repository;
        _authenticatedUser = authenticatedUser;
    }

    /// <summary>
    /// Request handler
    /// </summary>
    /// <param name="request">Get stock request</param>
    /// <param name="cancellationToken"></param>
    /// <returns>get stock response dto</returns>
    /// <exception cref="Exceptions.ApplicationLayerException"></exception>
    public async Task<GetStockResponse> Handle(GetStockRequest request, CancellationToken cancellationToken)
    {
        var u = _authenticatedUser.User;
        _validator.Validate(request);
        Product? product = null;
        if (request.ProductId != null)
        {
            product = await _repository.GetProductByArticleNumber(request.ProductId, request.Country);
            if (product is null)
            {
                throw new Exceptions.ApplicationLayerException($"Product not found by this product id: {request.ProductId}");
            }
        }
        else
        {
            if (request.EAN != null)
            {
                product = await _repository.GetProductByEAN(request.EAN, request.Country);
                if (product is null)
                {
                    throw new Exceptions.ApplicationLayerException($"Product not found by this ean: {request.EAN}");
                }
            }
        }
        return new GetStockResponse
        {
            Amount = product!.Stocks,
            Price = product!.ActivePrice?.Price ?? 0,
            ProductId = product!.Id,
        };
    }
}
