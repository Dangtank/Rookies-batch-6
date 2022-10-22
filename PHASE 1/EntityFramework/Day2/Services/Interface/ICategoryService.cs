using Day2.DTOs.Category;
using Day2.Models;

namespace Day2.Services.Interface
{
    public interface ICategoryService
    {
        AddCategoryResponse? Create(AddCategory addCategory);
        IEnumerable<Category> GetAll();
        OneCategoryResponse GetOne(int categoryId);
        UpdateCategoryResponse Update(int categoryId, UpdateCategory updateCategory);
        bool Delete(int categoryId);
    }
}