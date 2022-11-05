using TestWebAPI.DTOs.Category;
using Test.Data.Entities;

namespace TestWebAPI.Services.Interfaces
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