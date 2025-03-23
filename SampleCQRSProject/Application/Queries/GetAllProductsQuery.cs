using MediatR;
using SampleCQRSProject.Domain.Entities;

namespace SampleCQRSProject.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>> { }
}
