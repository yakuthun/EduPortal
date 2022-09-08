﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ICategoryRepository:IGenericRepositories<Category>
    {
        Task<Category> AddCategoryAsync(Category entity);
    }
}
