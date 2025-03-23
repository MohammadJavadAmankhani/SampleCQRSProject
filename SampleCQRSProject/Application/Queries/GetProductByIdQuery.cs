using MediatR;
using SampleCQRSProject.Domain.Entities;

namespace SampleCQRSProject.Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
