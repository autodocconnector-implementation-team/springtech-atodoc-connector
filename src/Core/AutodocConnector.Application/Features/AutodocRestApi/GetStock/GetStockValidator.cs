namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock;

public class GetStockRequestValidator: AbstractValidator<GetStockRequest>
{
    /// <summary>
    /// GetStockRequest fluent validator class
    /// </summary>
    public GetStockRequestValidator()
    {
        // ProductId and EAN code cannot both be empty
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.ProductId == null && request.EAN == null)
            {
                context.AddFailure("The ProductId and EAN cannot be both empty");
                return false;
            }
            return true;
        });
    }
}
