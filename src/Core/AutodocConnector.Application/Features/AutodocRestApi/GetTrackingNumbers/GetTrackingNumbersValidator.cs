using AutodocConnector.Application.Features.AutodocRestApi.GetTrackingNumbers.DTOs;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetTrackingNumbers;

public class GetTrackingNumbersValidator : AbstractValidator<GetTrackingNumbersRequest>
{
    public GetTrackingNumbersValidator()
    {
        // orderID cannot be empty
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.OrderID == null)
            {
                context.AddFailure("The OrderID cannot be empty");
                return false;
            }
            return true;
        });
    }
}

