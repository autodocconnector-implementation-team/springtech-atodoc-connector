namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder;
public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x).Must((_, request, context) =>
        {
            if (request.Items == null || request.Items.Count == 0)
            {
                context.AddFailure("You can't place an order that contains no items.");
                return false;
            }
            if (request.FirstName == null || request.LastName == null)
            {
                context.AddFailure("The firstname and lastname fields are mandatory.");
                return false;
            }


            return true;
        });
    }
}
