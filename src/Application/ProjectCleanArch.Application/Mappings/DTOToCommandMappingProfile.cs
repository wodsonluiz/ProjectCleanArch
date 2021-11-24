using AutoMapper;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Mediator.Products.Commands;

namespace ProjectCleanArch.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
        }
    }
}
