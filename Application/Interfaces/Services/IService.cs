using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Application.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        //educationRepository.GetAll(x=> x.id>5).toList();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity); //create, insert
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        //productRepository.where(x=>x.id>5).ToListAsync;
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
