using AutoMapper;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mappings
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
