using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SampleCQRSProject.Application.Queries;
using SampleCQRSProject.Domain.Entities;
using SampleCQRSProject.Domain.Interfaces;

namespace SampleCQRSProject.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
