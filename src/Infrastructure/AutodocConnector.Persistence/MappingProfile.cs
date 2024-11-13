using DbModels = AutodocConnector.Persistence.Models;
using Domain = AutodocConnector.Domain;
using AutoMapper;

namespace AutodocConnector.Persistence;
/// <summary>
/// Mappings between Persistence model and Domain models
/// </summary>
internal class MappingProfile : Profile
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Guid, String>()
            .ConvertUsing(s => s.ToString("D"));
        CreateMap<DbModels.Product, Domain.Products.Models.Product>();
        CreateMap<DbModels.AutodocUser, Domain.Users.Models.AutodocUser>();
    }
}
