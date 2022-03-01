using AutoMapper;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mappings
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
