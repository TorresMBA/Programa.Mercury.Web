using Mercury.Core.Entities;
using Mercury.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mercury.Infrastructure.Repositories {
    public class GenericRepositoy<T> : IGenericRepositoy<T> where T : BaseEntity {

        protected readonly MercuryContext _mercuryContext;

        public GenericRepositoy(MercuryContext mercuryContext)
        {
            _mercuryContext = mercuryContext;
        }

        public void Add(T entity)
        {
            _mercuryContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _mercuryContext.Set<T>().ToListAsync();
        }

        public Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
