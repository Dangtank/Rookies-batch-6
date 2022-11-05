using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.DTOs.Category
{
    public class UpdateCategoryRequest
    {
        public Guid CategoryId{get; set;}
        public string CategoryName { get; set; }

    }
}