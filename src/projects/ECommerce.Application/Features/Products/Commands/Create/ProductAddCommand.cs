﻿using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Constants;
using ECommerce.Application.Features.Products.Rules;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Create;

public class ProductAddCommand: IRequest<ProductAddResponseDto>,ISecuredRequest
{
    public string Name { get; set; }    
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int  Stock { get; set; }
    
    public int SubCategoryId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
    
    public class ProductAddCommandHandler :IRequestHandler<ProductAddCommand, ProductAddResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public ProductAddCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }
        
        public async Task<ProductAddResponseDto> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            
            var created= await _productRepository.AddAsync(product);
            
            var response= _mapper.Map<ProductAddResponseDto>(created);
            
            return response;
        }
    }
}