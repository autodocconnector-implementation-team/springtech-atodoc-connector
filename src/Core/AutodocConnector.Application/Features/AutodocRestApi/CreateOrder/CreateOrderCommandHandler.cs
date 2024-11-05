
namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    private readonly CreateOrderRequestValidator validator;
    private readonly ICreateOrderRepository repository;

    public CreateOrderCommandHandler(CreateOrderRequestValidator validator, ICreateOrderRepository repository)
    {
        this.validator = validator;
        this.repository = repository;
    }
    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            validator.Validate(request);


            //todo
            CreateOrderResponse response = new();
            return response;
        }
        catch (Exception e)
        {
            var response = new CreateOrderResponse();
            response.SetError(e.Message);
            return response;
        }
    }
}