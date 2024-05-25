using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository productRepository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            productRepository = repository ?? throw new ArgumentNullException(nameof(IProductRepository));
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
              var product = await productRepository.GetProductByIdAsync(request.Id);
              

              if(product == null){
                  throw new ApplicationException("Error! not be found");
              }else{
                
                product.Update(request.Name, request.Description, request.Price, request.Stock,request.Image, 
                               request.CategoryId);

                 return await productRepository.UpdateAsync(product);
              }
        }
    }
}