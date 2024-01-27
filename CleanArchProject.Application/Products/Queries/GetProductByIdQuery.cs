using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int? Id { get; set; }
        public GetProductByIdQuery(int? id)
        {
            Id = id;
        }
    }
}
