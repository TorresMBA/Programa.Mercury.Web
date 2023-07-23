using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Core.Interfaces {
    public interface IUnitOfWork {

        ICategoryRepository Category { get; }

        Task<int> SaveAsync();
    }
}
