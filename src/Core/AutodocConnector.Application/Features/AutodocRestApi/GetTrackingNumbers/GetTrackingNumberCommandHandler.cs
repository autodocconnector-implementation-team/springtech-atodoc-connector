using AutodocConnector.Application.Features.AutodocRestApi.GetTrackingNumbers.DTOs;
using AutodocConnector.Domain.Parcels.Models;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetTrackingNumbers;

public class GetTrackingNumberCommandHandler : IRequestHandler<GetTrackingNumbersRequest, GetTrackingNumbersResponse>
{
    private readonly GetTrackingNumbersValidator _validator;
    private readonly IGetTrackingNumbersRepository _repository;
    public GetTrackingNumberCommandHandler(GetTrackingNumbersValidator validator, IGetTrackingNumbersRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }
    public async Task<GetTrackingNumbersResponse> Handle(GetTrackingNumbersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _validator.Validate(request);
            List<Parcel> parcels = await _repository.GetParcelsByOrderId(request.OrderId);           

            return new GetTrackingNumbersResponse()
            {
                OrderId = request!.OrderId,
                Parcels = parcels
            };
        }
        catch (Exception ex)
        { 
            var response = new GetTrackingNumbersResponse();
            response.SetError(ex.Message);
            return response;
        }
    }
}
