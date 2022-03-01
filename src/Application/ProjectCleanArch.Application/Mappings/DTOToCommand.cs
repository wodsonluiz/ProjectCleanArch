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
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();

            CreateMap<CategoryDTO, CategoryCreateCommand>().ReverseMap();
            CreateMap<CategoryDTO, CategoryUpdateCommand>().ReverseMap();
        }
    }
}
