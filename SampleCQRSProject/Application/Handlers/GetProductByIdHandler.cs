using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SampleCQRSProject.Application.Queries;
using SampleCQRSProject.Domain.Entities;
using SampleCQRSProject.Domain.Interfaces;

namespace SampleCQRSProject.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
