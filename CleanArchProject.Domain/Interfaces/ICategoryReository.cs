using CleanArchProject.Domain.Entities;

namespace CleanArchProject.Domain.Interfaces
{
    public interface ICategoryReository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int? id);
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
    }
}
