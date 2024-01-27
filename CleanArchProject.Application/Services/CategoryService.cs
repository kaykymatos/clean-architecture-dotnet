using AutoMapper;
using CleanArchProject.Application.Categories.Commands;
using CleanArchProject.Application.Categories.Queries;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using MediatR;

namespace CleanArchProject.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _productMediator;
        private readonly IMapper _mapper;
        public CategoryService(IMediator productMediator, IMapper mapper)
        {
            _productMediator = productMediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoryQuery = new GetCategoriesQuery();
            var categories = await _productMediator.Send(categoryQuery);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryQuery = new GetCategoryByIdQuery(id);
            var categoriy = await _productMediator.Send(categoryQuery);
            return _mapper.Map<CategoryDTO>(categoriy);
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var categoryQuery = _mapper.Map<CategoryCreateCommand>(categoryDto);
            await _productMediator.Send(categoryQuery);
        }

        public async Task Update(CategoryDTO categoryDto)
        {

            var categoryQuery = _mapper.Map<CategoryUpdateCommand>(categoryDto);
            await _productMediator.Send(categoryQuery);
        }

        public async Task Remove(int? id)
        {
            var result = new CategoryRemoveCommand(id);
            if (result == null)
                throw new Exception("Product remove invalid!");
            await _productMediator.Send(result);
        }
    }
}
