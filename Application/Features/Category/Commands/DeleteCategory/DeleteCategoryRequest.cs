﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.DeleteCategory
{
    public record DeleteCategoryRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteCategoryRequest(int id)
        {
            Id = id;
        }
    }
}
