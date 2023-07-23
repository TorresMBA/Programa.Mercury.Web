using Mercury.Core.Entities;
using Mercury.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Infrastructure.Repositories {
    public class CategoryRepository : GenericRepositoy<Category>, ICategoryRepository {
        public CategoryRepository(MercuryContext mercuryContext) : base(mercuryContext)
        {
        }
    }
}
