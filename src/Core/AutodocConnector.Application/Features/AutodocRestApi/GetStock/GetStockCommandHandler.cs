namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock;

public class GetStockCommandHandler : IRequestHandler<GetStockRequest, GetStockResponse>
{
    private readonly GetStockValidator _validator;
    private readonly IGetStockRepository _repository;

    public GetStockCommandHandler(GetStockValidator validator, IGetStockRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<GetStockResponse> Handle(GetStockRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _validator.Validate(request);
            Product? product = null;
            if (request.ProductId != null)
            {
                product = await _repository.GetProductByArticleNumber(request.ProductId, request.Country);
                if (product is null)
                {
                    throw new ApplicationException($"Product not found by this product id: {request.ProductId}");
                }
            }
            else
            {
                if (request.EAN != null)
                {
                    product = await _repository.GetProductByEAN(request.EAN, request.Country);
                    if (product is null)
                    {
                        throw new ApplicationException($"Product not found by this ean: {request.EAN}");
                    }
                }
            }
            return new GetStockResponse
            {
                Amount = product!.Stocks,
                Price = product!.ActivePrice!.Price,
                ProductId = product!.Id,
            };
        }
        catch (Exception ex)
        {
            var response = new GetStockResponse();
            response.SetError(ex.Message);
            return response;
        }
    }
}
