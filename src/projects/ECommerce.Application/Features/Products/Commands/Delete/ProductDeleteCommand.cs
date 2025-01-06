
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.Security.Constants;
using ECommerce.Application.Features.Products.Commands.Create;
using Ecommerce.Application.Services.Repositories;
using MediatR;


namespace ECommerce.Application.Features.Products.Commands.Delete;
public class ProductDeleteCommand : MediatR.IRequest<string>,
    ICacheRemoverRequest,
    ILoggableRequest,
    ISecuredRequest,
    ITransactionalRequest
{
    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "Products";

    public string[] Roles => [GeneralOperationClaims.Admin];

    
    public Guid Id { get; set; }
    
    
    public sealed class ProductDeleteCommandHandler: IRequestHandler<ProductDeleteCommand,string>
    {
        private readonly IProductRepository _productRepository;
        

        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
          
        }


        public async Task<string> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
           
            


            return "Ürün Silindi.";

        }
        
    }
}