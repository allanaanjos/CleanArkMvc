using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository productRepository;
        public ProductCreateCommandHandler(IProductRepository repository)
        {
           productRepository = repository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, 
                                     request.Image);
            
            if(product == null){
               throw new ApplicationException("Error! Creating Entity.");
            }
            else{

                product.CategoryId = request.CategoryId;
                return await productRepository.CreateAsync(product);
            }
        }
    }
}