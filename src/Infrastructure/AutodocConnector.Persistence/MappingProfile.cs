using DbModels = AutodocConnector.Persistence.Models;
using DomainModels = AutodocConnector.Domain.Products.Models;
using AutoMapper;

namespace AutodocConnector.Persistence;
internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Guid, String>()
            .ConvertUsing(s => s.ToString("N"));
        CreateMap<DbModels.Product, DomainModels.Product>();
    }
}
