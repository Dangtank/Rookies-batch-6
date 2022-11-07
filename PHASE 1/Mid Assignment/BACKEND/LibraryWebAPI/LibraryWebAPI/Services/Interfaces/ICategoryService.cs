using LibraryWebAPI.DTOs.Category;
using Library.Data.Entities;

namespace LibraryWebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        AddCategoryResponse? Create(AddCategoryRequest addCategoryRequest);
        IEnumerable<Category> GetAll();
        OneCategoryResponse GetOne(Guid categoryId);
        UpdateCategoryResponse Update(UpdateCategoryRequest updateCategoryRequest);
        bool Delete(Guid categoryId);
    }
}