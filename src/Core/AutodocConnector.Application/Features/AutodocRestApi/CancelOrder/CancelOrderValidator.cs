using AutodocConnector.Application.Features.AutodocRestApi.CancelOrder.DTOs;

namespace AutodocConnector.Application.Features.AutodocRestApi.CancelOrder;

public class CancelOrderValidator : AbstractValidator<CancelOrderRequest>
{
    public CancelOrderValidator()
    {
        // OrderId cannot be empty
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.OrderId == null)
            {
                context.AddFailure("The OrderId cannot be empty");
                return false;
            }
            return true;
        });
    }
}
