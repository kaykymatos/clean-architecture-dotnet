using CleanArchProject.Application.Categories.Commands;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using MediatR;

namespace CleanArchProject.Application.Categories.Handlers
{
    public class CategoryUpdateComnandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryUpdateComnandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new ApplicationException("Product not found!");
            }
            else
            {
                category.UpdateName(request.Name);
                var result = await _categoryRepository.UpdateAsync(category);
                return result;
            }
        }
    }
}
