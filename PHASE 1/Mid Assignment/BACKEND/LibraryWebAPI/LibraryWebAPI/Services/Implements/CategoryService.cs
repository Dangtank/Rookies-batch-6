using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using LibraryWebAPI.DTOs.Category;
using LibraryWebAPI.Services.Interfaces;

namespace LibraryWebAPI.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public AddCategoryResponse? Create(AddCategoryRequest addCategoryRequest)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var categoryAlreadyExist = _categoryRepository.GetOne(i => i.CategoryName.ToLower() == addCategoryRequest.CategoryName.ToLower());

                    var newCategory = new Category
                    {
                        CategoryId = Guid.NewGuid(),
                        CategoryName = addCategoryRequest.CategoryName,
                    };

                    if (categoryAlreadyExist == null)
                    {
                        _categoryRepository.Create(newCategory);
                        _categoryRepository.SaveChanges();
                        transaction.Commit();

                        return new AddCategoryResponse
                        {
                            CategoryId = newCategory.CategoryId,
                            CategoryName = newCategory.CategoryName,
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

        public bool Delete(Guid categoryId)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var deleteCategory = _categoryRepository.GetOne(i => i.CategoryId == categoryId);

                    if (deleteCategory != null)
                    {
                        _categoryRepository.Delete(deleteCategory);
                        _categoryRepository.SaveChanges();
                        transaction.Commit();
                    }

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
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var categories = _categoryRepository.GetAllCategory();

                    transaction.Commit();

                    return categories;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public OneCategoryResponse GetOne(Guid categoryId)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var category = _categoryRepository.GetOne(i => i.CategoryId == categoryId);

                    if (category != null)
                    {
                        transaction.Commit();
                    }

                    return new OneCategoryResponse
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

        public UpdateCategoryResponse Update(UpdateCategoryRequest updateCategoryRequest)
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())
                try
                {
                    var category = _categoryRepository.GetOne(i => i.CategoryId == updateCategoryRequest.CategoryId);

                    if (category != null)
                    {
                        category.CategoryName = updateCategoryRequest.CategoryName;

                        _categoryRepository.Update(category);
                        _categoryRepository.SaveChanges();
                        transaction.Commit();

                        return new UpdateCategoryResponse
                        {
                            CategoryId = category.CategoryId,
                            CategoryName = category.CategoryName
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
    }
}