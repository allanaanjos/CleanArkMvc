using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository productRepository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            productRepository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductsAsync();
        }
    }
}