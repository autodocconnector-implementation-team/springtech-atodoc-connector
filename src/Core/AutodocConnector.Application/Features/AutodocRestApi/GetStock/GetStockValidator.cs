namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock;

/// <summary>
/// Get stock request validator
/// </summary>
public class GetStockValidator: AbstractValidator<GetStockRequest>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public GetStockValidator()
    {
        // ProductId and EAN code cannot both be empty
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.ProductId == null && request.EAN == null)
            {
                throw new Exceptions.ApplicationLayerException("The ProductId and EAN cannot be both empty");
            }
            return true;
        });
    }
}
