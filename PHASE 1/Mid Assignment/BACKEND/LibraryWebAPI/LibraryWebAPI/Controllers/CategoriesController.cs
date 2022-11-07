
using LibraryWebAPI.DTOs.Category;
using LibraryWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateNewCategory([FromBody] AddCategoryRequest addCategoryRequest)
        {
            try
            {
                var data = _categoryService.Create(addCategoryRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            {
                try
                {
                    var data = _categoryService.GetAll();

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOneCategory(Guid id)
        {
            {
                try
                {
                    var data = _categoryService.GetOne(id);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var data = _categoryService.Delete(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            try
            {
                var data = _categoryService.Update(updateCategoryRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }
    }
}