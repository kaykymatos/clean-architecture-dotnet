using AutoMapper;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Domain.Entities;

namespace CleanArchProject.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

        }
    }
}
