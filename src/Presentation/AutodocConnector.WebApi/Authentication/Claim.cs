using Newtonsoft.Json;

namespace AutodocConnector.WebApi.Authentication;

/// <summary>
/// Defined claims
/// </summary>
/// <typeparam name="TType">Enum which holdes th defined claim types</typeparam>
/// <typeparam name="TValue">Type of claim value</typeparam>
internal class Claim<TType, TValue> 
    where TType : Enum
    where TValue : class
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type of cliam</param>
    /// <param name="value">Value of claim</param>
    public Claim(TType type, TValue value)
    {
        _type = type;
        _value = value;
    }

    private readonly TType _type;
    /// <summary>
    /// Get type of claim as string
    /// </summary>
    public string Type => _type.ToString();

    /// <summary>
    /// Get value of claim as serialized string
    /// </summary>
    private readonly TValue _value;
    public string Value => JsonConvert.SerializeObject(_value);
}
