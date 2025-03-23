using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SampleCQRSProject.Application.Commands;
using SampleCQRSProject.Domain.Entities;
using SampleCQRSProject.Domain.Events;
using SampleCQRSProject.Domain.Interfaces;

namespace SampleCQRSProject.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repository;
        private readonly IEventStore _eventStore;

        public CreateProductHandler(IProductRepository repository, IEventStore eventStore)
        {
            _repository = repository;
            _eventStore = eventStore;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { Name = request.Name, Price = request.Price };
            var productId = await _repository.CreateAsync(product);

            var productCreatedEvent = new ProductCreatedEvent(productId, request.Name, request.Price);
            await _eventStore.SaveEventAsync(productCreatedEvent);

            return productId;
        }
    }
}
