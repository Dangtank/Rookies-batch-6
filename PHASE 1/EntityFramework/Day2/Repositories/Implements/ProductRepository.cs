using Day2.Data;
using Day2.Models;
using Day2.Repositories.Interfaces;

namespace Day2.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductStoreContext context) : base (context)
        {}
    }
}