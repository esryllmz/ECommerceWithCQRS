﻿using Core.Persistence.Repositories;

namespace Ecommerce.Domain.Entities;

public sealed class SubCategory : Entity<int>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
}