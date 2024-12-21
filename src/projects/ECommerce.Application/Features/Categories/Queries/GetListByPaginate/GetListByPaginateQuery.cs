
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Extensions;
using Ecommerce.Persistence.Abstracts;
using ECommerce.Application.Features.Categories.Queries.GetList;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetListByPaginate;

public class GetListByPaginateCategoryQuery : IRequest<Paginate<GetListByIdCategoryResponseDto>>
{
    public PageRequest PageRequest { get; set; }

    public sealed class GetListByPaginateCategoryQueryHandler :
        IRequestHandler <GetListByPaginateCategoryQuery, Paginate<GetListByIdCategoryResponseDto>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListByPaginateCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListByIdCategoryResponseDto>> Handle(GetListByPaginateCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetPaginateAsync(
                include: false,
                enableTracking: false,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            var response= _mapper.Map<Paginate<GetListByIdCategoryResponseDto>>(categories);
            return response;

        }
    }
}
