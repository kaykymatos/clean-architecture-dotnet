using CleanArchProject.Application.Categories.Commands;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using MediatR;

namespace CleanArchProject.Application.Categories.Handlers
{
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryRemoveCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(CategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _categoryRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Product not found!");
            }
            else
            {
                var result = await _categoryRepository.RemoveAsync(product);
                return result;
            }
        }
    }
}
