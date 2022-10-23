using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Core.Entities
{
    public class Articles : BaseEntity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
