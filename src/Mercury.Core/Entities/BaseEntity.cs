using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedByUser { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }
    }
}
