using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; } 
    }
}
