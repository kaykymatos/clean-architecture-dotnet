using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int? Id { get; set; }
        public GetCategoryByIdQuery(int? id)
        {
            Id = id;
        }
    }
}
