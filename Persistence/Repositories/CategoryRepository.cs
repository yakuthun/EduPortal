using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepositories<Category>, ICategoryRepository
    {
        private readonly DbContext _context;//veritabanı işlemleri için DbContext'e ihtiyaç var
        private readonly DbSet<Category> _dbSet;//tablolar üzerinde işlem yapabilmemiz için DbSet ekleyelim.
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Category>(); 
        }

        public Task<Category> AddCategoryAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
