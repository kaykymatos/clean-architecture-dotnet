using AutoMapper;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using CleanArchProject.Application.Products.Commands;
using CleanArchProject.Application.Products.Queries;
using MediatR;

namespace CleanArchProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _productMediator;

        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IMediator productMediator)
        {
            _productMediator = productMediator ??
                 throw new ArgumentNullException(nameof(productMediator));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new ApplicationException("Query is null!");

            var result = await _productMediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productsQuery = new GetProductByIdQuery(id);
            if (productsQuery == null)
                throw new ApplicationException("Query is null!");

            var result = await _productMediator.Send(productsQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO productDto)
        {
            var retult = _mapper.Map<ProductCreateCommand>(productDto);
            await _productMediator.Send(retult);

        }

        public async Task Update(ProductDTO productDto)
        {
            var retult = _mapper.Map<ProductUpdateCommand>(productDto);
            await _productMediator.Send(retult);
        }

        public async Task Remove(int? id)
        {
            var result = new ProductRemoveCommand(id);
            if (result == null)
                throw new Exception("Product remove invalid!");
            await _productMediator.Send(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetByCategoryId(int? idCategory)
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new ApplicationException("Query is null!");

            var result = await _productMediator.Send(productsQuery);
            var products = _mapper.Map<IEnumerable<ProductDTO>>(result);
            return products.Where(x => x.CategoryId == idCategory);
        }
    }
}
