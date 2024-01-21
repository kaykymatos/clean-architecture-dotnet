using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int? Id { get; set; }
        public ProductRemoveCommand(int? id)
        {
            Id = id;
        }
    }
}
