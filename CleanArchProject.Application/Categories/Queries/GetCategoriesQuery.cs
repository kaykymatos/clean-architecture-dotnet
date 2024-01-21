using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
