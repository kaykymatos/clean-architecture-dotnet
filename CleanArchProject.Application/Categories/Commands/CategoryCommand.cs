using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Categories.Commands
{
    public class CategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
