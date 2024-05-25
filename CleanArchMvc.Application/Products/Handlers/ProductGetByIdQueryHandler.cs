using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductGetByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository productRepository;

        public ProductGetByIdQueryHandler(IProductRepository repository)
        {
            productRepository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductByIdAsync(request.Id);
        }
    }
}