using Day2.DTOs.Category;
using Day2.DTOs.Product;
using Day2.Models;

namespace Day2.Services.Interface
{
    public interface IProductService
    {
        AddProductResponse? Create(AddProduct addProduct);
        IEnumerable<Product> GetAll();
        OneProductResponse GetOne(int productId);
        UpdateProductResponse Update(int productId, UpdateProduct updateProduct);
        bool Delete(int productId);
    }
}