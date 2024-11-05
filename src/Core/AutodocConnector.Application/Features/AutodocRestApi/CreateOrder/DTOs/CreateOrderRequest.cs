namespace AutodocConnector.Application.Features.AutodocRestApi.CreateOrder.DTOs;

public record CreateOrderRequest : IRequest<CreateOrderResponse>
{
    /// <summary>
    /// The items associated with the order
    /// </summary>
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    /// <summary>
    /// The order ID. Must be unique and is required.
    /// </summary>
    public string AutodocOrderId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    /// <summary>
    /// Address description according to the examples is something like "Floor 4, Door 16".
    /// </summary>
    public string AddressDescription { get; set; }
    /// <summary>
    /// ZIP is the postal code for different regions. Ex: Budapest, Lipotvaros - 1051
    /// </summary>
    public string ZipCode { get; set; }
    public string City { get; set; }
    /// <summary>
    /// The alpha 2 country code of the country. See more : https://www.iban.com/country-codes
    /// </summary>
    public string CountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
}
