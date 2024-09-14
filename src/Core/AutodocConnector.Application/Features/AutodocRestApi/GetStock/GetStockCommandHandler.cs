namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock;

public class GetStockCommandHandler : IRequestHandler<GetStockRequest, GetStockResponse>
{
    private readonly GetStockRequestValidator _validator;
    private readonly IGetStockRepository _repository;

    public GetStockCommandHandler(GetStockRequestValidator validator, IGetStockRepository repository)
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
                product = await _repository.GetProductByArticleNumberAsync(request.ProductId, request.Country);
            }
            else
            {
                if (request.EAN != null)
                {
                    product = await _repository.GetProductByEANAsync(request.EAN, request.Country);
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
