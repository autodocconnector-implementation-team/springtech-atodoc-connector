using AutodocConnector.Application.Features.AutodocRestApi.GetOrderStatus.DTOs;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetOrderStatus;

public class GetOrderStatusValidator : AbstractValidator<GetOrderStatusRequest>
{
    public GetOrderStatusValidator()
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
