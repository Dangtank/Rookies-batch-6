using Day2.DTOs.Category;
using Day2.Models;
using Day2.Repositories.Interfaces;
using Day2.Services.Interface;

namespace Day2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categogyRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categogyRepository = categoryRepository;
        }

        public AddCategoryResponse? Create(AddCategory addCategory)
        {
            using (var transaction = _categogyRepository.DatabaseTransaction())
                try
                {
                    var newCategory = new Category
                    {
                        CategoryName = addCategory.CategoryName,
                    };

                    _categogyRepository.Create(newCategory);
                    _categogyRepository.SaveChanges();
                    transaction.Commit();

                    return new AddCategoryResponse
                    {
                        CategoryId = newCategory.CategoryId,
                        CategoryName = newCategory.CategoryName,
                    };

                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public bool Delete(int categoryId)
        {
            using (var transaction = _categogyRepository.DatabaseTransaction())
                try
                {
                    var deleteCategory = _categogyRepository.Get(i => i.CategoryId == categoryId);

                    if (deleteCategory != null)
                    {
                        _categogyRepository.Delete(deleteCategory);
                        _categogyRepository.SaveChanges();
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

        public IEnumerable<Category> GetAll()
        {
            using (var transaction = _categogyRepository.DatabaseTransaction())
                try
                {
                    var categories = _categogyRepository.GetAll(p => true);
                    transaction.Commit();

                    return categories;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public OneCategoryResponse GetOne(int categoryId)
        {
            using (var transaction = _categogyRepository.DatabaseTransaction())
                try
                {
                    var category = _categogyRepository.Get(i => i.CategoryId == categoryId);

                    if (category != null)
                    {
                        return new OneCategoryResponse
                        {
                            CategoryId = category.CategoryId,
                            CategoryName = category.CategoryName
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

        public UpdateCategoryResponse Update(int categoryId, UpdateCategory updateCategory)
        {
            using (var transaction = _categogyRepository.DatabaseTransaction())
                try
                {
                    var category = _categogyRepository.Get(i => i.CategoryId == categoryId);

                    if (category != null)
                    {
                        category.CategoryId = category.CategoryId;
                        category.CategoryName = updateCategory.CategoryName;
                    }

                    _categogyRepository.Update(category);
                    _categogyRepository.SaveChanges();
                    transaction.Commit();

                    return new UpdateCategoryResponse
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName
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