using CleanArchProject.Application.DTOs;

namespace CleanArchProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);
        Task<IEnumerable<ProductDTO>> GetByCategoryId(int? idCategory);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Remove(int? id);
    }
}
