using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Update;

public class ProductUpdateCommand : MediatR.IRequest<ProductUpdateResponseDto>, ITransactionalRequest,ICacheRemoverRequest
   // ,ISecuredRequest 
{
    public Guid Id { get; set; }
    public string Name { get; set; }    
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int  Stock { get; set; }
    
    public int SubCategoryId { get; set; }
    public string CacheKey => "";

    public bool ByPassCache => false;
    public string? CacheGroupKey => "Products";
   // public string[] Roles => [GeneralOperationClaims.Admin];
    
    
    public class ProductUpdateCommandHandler: IRequestHandler<ProductUpdateCommand,ProductUpdateResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
  

        public ProductUpdateCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
         
        }


        public async Task<ProductUpdateResponseDto> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {

            throw new Exception();
            

        }
    }
    
}