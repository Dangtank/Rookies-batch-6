
using Day2.DTOs.Category;
using Day2.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace Day2.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateNewCategory([FromBody] AddCategory addCategory)
        {
            {
                try
                {
                    var data = _categoryService.Create(addCategory);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
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
        public IActionResult GetOneCategory(int id)
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
        public IActionResult Delete(int id)
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
        public IActionResult Edit([FromQuery] int id, [FromBody] UpdateCategory updateCategory)
        {
            try
            {
                var data = _categoryService.Update(id, updateCategory);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }
    }
}