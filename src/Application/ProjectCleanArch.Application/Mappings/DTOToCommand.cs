using AutoMapper;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Mediator.Categories.Commands;
using ProjectCleanArch.Application.Mediator.Products.Commands;

namespace ProjectCleanArch.Application.Mappings
{
    public class DTOToCommand : Profile
    {
        public DTOToCommand()
        {
            CreateMap<ProductDto, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDto, ProductUpdateCommand>().ReverseMap();

            CreateMap<CategoryDto, CategoryCreateCommand>().ReverseMap();
            CreateMap<CategoryDto, CategoryUpdateCommand>().ReverseMap();
        }
    }
}
