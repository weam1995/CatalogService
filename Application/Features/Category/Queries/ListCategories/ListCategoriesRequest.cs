﻿using CatalogService.Application.Features.Category.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.ListCategories
{
    public record ListCategoriesRequest : IRequest<List<CategoryDto>>
    {
    }
}