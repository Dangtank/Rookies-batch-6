using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetAllCategory();
    }
}