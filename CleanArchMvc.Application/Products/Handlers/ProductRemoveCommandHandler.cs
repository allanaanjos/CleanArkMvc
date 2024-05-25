using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository productRepository;
        public ProductRemoveCommandHandler(IProductRepository repository)
        {
            productRepository = repository;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductByIdAsync(request.Id);

            if(product == null){
                 throw new ApplicationException("Error! not be found");
            }else{
                var result = await productRepository.DeleteAsync(product);
                return result;
            }
        }
    }
}