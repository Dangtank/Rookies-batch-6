using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Models
{
    public class FilterModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }
}