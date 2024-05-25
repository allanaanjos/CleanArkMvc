using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interface;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCommand);

        }

        //public async Task<ProductDTO> GetProductCategoriesAsync(int? id)
        //{
        //     var productQuery = new GetProductByIdQuery(id.Value);

        //      if (productQuery == null)
        //         throw new ArgumentNullException("Error could not be load");

        //     var result = await _mediator.Send(productQuery);
        //     return _mapper.Map<ProductDTO>(result);
        // }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productHandler = new GetProductsQuery();

            if (productHandler == null)
                throw new ApplicationException("Error! could not be loaded.");

            var Result = await _mediator.Send(productHandler);

            return _mapper.Map<IEnumerable<ProductDTO>>(Result);
        }

        public async Task<ProductDTO> ProductById(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);

            if (productQuery == null)
                throw new ArgumentNullException("Error could not be load");

            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Remove(int? id)
        {
            var productCommand = new ProductRemoveCommand(id.Value);

            if (productCommand == null)
                throw new Exception("Entity could not be load");

            await _mediator.Send(productCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productCommand);
        }
    }
}

