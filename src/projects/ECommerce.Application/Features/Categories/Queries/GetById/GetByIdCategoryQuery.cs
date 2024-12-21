
using AutoMapper;
using Ecommerce.Persistence.Abstracts;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryQuery:IRequest<GetByIdCategoryResponseDto>
{
    public int Id { get; set; }

    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryResponseDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category=await _categoryRepository.GetAsync(predicate: x=> x.Id == request.Id);
            return _mapper.Map<GetByIdCategoryResponseDto>(category);
        }
    }
}
