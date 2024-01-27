using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Categories.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public int? Id { get; set; }
        public CategoryRemoveCommand(int? id)
        {
            Id = id;
        }
    }
}
