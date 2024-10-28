using AutodocConnector.Application.Features.AutodocRestApi.CancelOrder.DTOs;

namespace AutodocConnector.Application.Features.AutodocRestApi.CancelOrder;

public class CancelOrderCommandHandler : IRequestHandler<CancelOrderRequest, CancelOrderResponse>
{
    private readonly CancelOrderValidator _validator;
    private readonly ICancelOrderRepository _repository;

    public CancelOrderCommandHandler(CancelOrderValidator validator, ICancelOrderRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<CancelOrderResponse> Handle(CancelOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _validator.Validate(request);
            await _repository.DeleteOrderByOrderIdAsync(request.OrderId);
            return new CancelOrderResponse();
        }
        catch (Exception ex)
        {
            var response = new CancelOrderResponse();
            response.SetError(ex.Message);
            return response;
        }
    }
}
