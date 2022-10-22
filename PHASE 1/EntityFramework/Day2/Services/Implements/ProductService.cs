using Day2.DTOs.Category;
using Day2.DTOs.Product;
using Day2.Models;
using Day2.Repositories.Interfaces;
using Day2.Services.Interface;

namespace Day2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categogyRepository;
        
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categogyRepository = categoryRepository;
        }
       
        public AddProductResponse? Create(AddProduct addProduct)
        {

            using (var transaction = _productRepository.DatabaseTransaction())
                try
                {
                    var category = _categogyRepository.Get(i => i.CategoryId == addProduct.CategoryId);

                    if (category != null)
                    {
                        var newProduct = new Product
                        {
                            ProductName = addProduct.ProductName,
                            CategoryId = category.CategoryId,
                            Manufacture = addProduct.Manufacture
                        };

                        _productRepository.Create(newProduct);
                        _productRepository.SaveChanges();
                        transaction.Commit();

                        return new AddProductResponse
                        {
                            ProductId = newProduct.ProductId,
                            ProductName = newProduct.ProductName,
                            CategoryId = newProduct.CategoryId,
                            Manufacture = newProduct.Manufacture
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public bool Delete(int productId)
        {
            using (var transaction = _productRepository.DatabaseTransaction())

                try
                {
                    var deleteProduct = _productRepository.Get(i => i.ProductId == productId);

                    if (deleteProduct != null)
                    {
                        _productRepository.Delete(deleteProduct);
                        _productRepository.SaveChanges();
                    }
                    transaction.Commit();
                    return true;

                }
                catch
                {
                    transaction.RollBack();

                    return false;
                }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var transaction = _productRepository.DatabaseTransaction())

                try
                {
                    var products = _productRepository.GetAll(p => true);

                    transaction.Commit();

                    return products;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public OneProductResponse GetOne(int productId)
        {
            using (var transaction = _productRepository.DatabaseTransaction())

                try
                {
                    var product = _productRepository.Get(i => i.ProductId == productId);

                    if (product != null)
                    {
                        return new OneProductResponse
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            Manufacture = product.Manufacture,
                            CategoryId = product.CategoryId
                        };

                    }
                    transaction.Commit();

                    return null;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public UpdateProductResponse Update(int productId, UpdateProduct updateProduct)
        {
            using (var transaction = _productRepository.DatabaseTransaction())

                try
                {
                    var product = _productRepository.Get(i => i.ProductId == productId);

                    if (product != null)
                    {
                        product.CategoryId = updateProduct.CategoryId;
                        product.ProductName = updateProduct.ProductName;
                        product.Manufacture = updateProduct.Manufacture;
                    }
                    _productRepository.Update(product);
                    _productRepository.SaveChanges();
                    transaction.Commit();

                    return new UpdateProductResponse
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Manufacture = product.Manufacture,
                        CategoryId = product.CategoryId
                    };
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }
    }
}
