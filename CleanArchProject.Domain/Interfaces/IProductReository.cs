using CleanArchProject.Domain.Entities;

namespace CleanArchProject.Domain.Interfaces
{
    public interface IProductReository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int? id);
        Task<Product> GetProductCategoryAsync(int? id);
        Task<Product> CreateAsync(Product category);
        Task<Product> UpdateAsync(Product category);
        Task<Product> RemoveAsync(Product category);
    }
}
