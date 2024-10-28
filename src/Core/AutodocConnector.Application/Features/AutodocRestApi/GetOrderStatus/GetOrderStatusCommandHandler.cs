using AutodocConnector.Application.Features.AutodocRestApi.GetOrderStatus.DTOs;
using AutodocConnector.Domain.OrderStatus.Models;
namespace AutodocConnector.Application.Features.AutodocRestApi.GetOrderStatus;

public class GetOrderStatusCommandHandler : IRequestHandler<GetOrderStatusRequest, GetOrderStatusResponse>
{
    private readonly GetOrderStatusValidator _validator;
    private readonly IGetOrderStatusRepository _repository;

    public GetOrderStatusCommandHandler(GetOrderStatusValidator validator, IGetOrderStatusRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }
    public async Task<GetOrderStatusResponse> Handle(GetOrderStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _validator.Validate(request);
            OrderStatus orderStatus = await _repository.GetOrderStatusByOrderIdAsync(request.OrderId);
            return new GetOrderStatusResponse()
            {
                OrderId = request!.OrderId,
                OrderStatus = orderStatus.StatusName
                //OrderStatus = orderStatus.StatusId         TODO either status name or id - to be decided
            };
        }
        catch (Exception ex)
        {
            var response = new GetOrderStatusResponse();
            response.SetError(ex.Message);
            return response;
        }
    }
}
