using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
