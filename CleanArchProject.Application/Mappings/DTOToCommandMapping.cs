using AutoMapper;
using CleanArchProject.Application.Categories.Commands;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Products.Commands;

namespace CleanArchProject.Application.Mappings
{
    public class DTOToCommandMapping : Profile
    {
        public DTOToCommandMapping()
        {
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();

            CreateMap<CategoryDTO, CategoryCreateCommand>().ReverseMap();
            CreateMap<CategoryDTO, CategoryUpdateCommand>().ReverseMap();
        }
    }
}
