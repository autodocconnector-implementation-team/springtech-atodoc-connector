namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock;

public class GetStockRequestValidator: AbstractValidator<GetStockRequest>
{
    /// <summary>
    /// GetStockRequest fluent validatot class
    /// </summary>
    public GetStockRequestValidator()
    {
        // ProductId and EAN code canot empty both
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.ProductId == null && request.EAN == null)
            {
                context.AddFailure("The ProductId and EAN connot be empty both");
                return false;
            }
            return true;
        });
    }
}
