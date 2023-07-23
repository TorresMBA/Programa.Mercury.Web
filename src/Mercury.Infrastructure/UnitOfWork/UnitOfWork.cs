using Mercury.Core.Interfaces;
using Mercury.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Infrastructure.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {

        private readonly MercuryContext _mercuryContext;

        private ICategoryRepository _category;

        public ICategoryRepository Category {
            get
            {
                if(_category == null) _category = new CategoryRepository(_mercuryContext);
                return _category;
            }
        }

        public UnitOfWork(MercuryContext mercuryContext)
        {
            _mercuryContext = mercuryContext;
        }

        public async Task<int> SaveAsync()
        {
            return await _mercuryContext.SaveChangesAsync();
        }
    }
}
