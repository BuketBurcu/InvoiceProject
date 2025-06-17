using AutoMapper;
using InvoiceApi.Data.Dtos;
using InvoiceApi.Data.Models;

namespace InvoiceApi.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceHeaderDto, InvoiceHeader>().ReverseMap();
            //CreateMap<InvoiceHeader, InvoiceHeaderDto>().ReverseMap();
            CreateMap<InvoiceLineDto, InvoiceLine>().ReverseMap();
            //CreateMap<InvoiceHeader, InvoiceDto>()
            //    .ForMember(x => x.InvoiceHeader, opt => opt.MapFrom(src => src));
        }
    }
}
