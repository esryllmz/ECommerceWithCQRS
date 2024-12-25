﻿

using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using ECommerce.Application.Features.Categories.Constants;
using System.Threading;
using Ecommerce.Application.Services.Repositories;

namespace ECommerce.Application.Features.Categories.Rules;

public class CategoryBusinessRules(ICategoryRepository _categoryRepository)
{
    public async Task CategoryIsPresentAsync(int id,CancellationToken cancellationToken)
    {
        bool isPresent = await _categoryRepository
            .AnyAsync( predicate: c => c.Id == id,
            cancellationToken: cancellationToken);

        if (!isPresent)
            throw new BusinessException(CategoryMessages.CategoryNotFoundMessage);

    }

    public async Task CategoryNameMustBeUniqueAsync(string name, CancellationToken cancellationToken)
    {
        bool isPresent = await _categoryRepository
          .AnyAsync(predicate: c => c.Name == name, 
          cancellationToken: cancellationToken);

        if (isPresent)
            throw new BusinessException(CategoryMessages.CategoryNameMustBeUniqueMessage);

    }




}
