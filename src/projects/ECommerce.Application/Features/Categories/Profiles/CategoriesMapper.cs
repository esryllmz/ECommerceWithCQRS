
using AutoMapper;
using Core.Persistence.Extensions;
using Ecommerce.Domain.Entities;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Features.Categories.Queries.GetListByPaginate;

namespace ECommerce.Application.Features.Categories.Profiles;

public class CategoriesMapper : Profile
{

    public CategoriesMapper()
    {
        CreateMap<CategoryAddCommand, Category>();
        CreateMap<Category,CategoryAddedResponseDto>();

        CreateMap<Category,GetListCategoryResponseDto>();

        CreateMap<Category, GetListByIdCategoryResponseDto>();
        CreateMap<Paginate<Category>, Paginate < GetListByIdCategoryResponseDto >>();

        CreateMap<Category,GetByIdCategoryResponseDto>();
   

    }
}
