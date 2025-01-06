using AutoMapper;
using Ecommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetList;

public class GetListProductQuery:IRequest <List<GetListProductResponseDto>>
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<GetListProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<List<GetListProductResponseDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            var products= await _productRepository.GetListAsync(
                enableTracking:false, 
                withDeleted:true, 
                cancellationToken:cancellationToken
                );
            
            return _mapper.Map<List<GetListProductResponseDto>>(products);
            
        }
    }
}