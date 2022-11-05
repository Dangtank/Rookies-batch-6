using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.DTOs.Book
{
    public class OneBookResponse
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public Guid CategoryId { get; set; }
    }
}