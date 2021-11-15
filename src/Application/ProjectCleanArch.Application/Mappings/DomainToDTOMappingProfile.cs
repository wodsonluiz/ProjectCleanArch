using AutoMapper;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
