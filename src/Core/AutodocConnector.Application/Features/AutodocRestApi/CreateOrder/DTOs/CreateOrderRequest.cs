namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder.DTOs;

public record CreateOrderRequest : IRequest<CreateOrderResponse>
{
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public string AutodocOrderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string AddressDescription { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string CountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
}
