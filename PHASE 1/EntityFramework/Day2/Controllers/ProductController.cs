using Day2.DTOs.Category;
using Day2.DTOs.Product;
using Day2.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateNewProduct([FromBody] AddProduct addProduct)
        {
            {
                try
                {
                    var data = _productService.Create(addProduct);

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
            }
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            {
                try
                {
                    var data = _productService.GetAll();

                    return Ok(data);
                }
                catch (Exception ex)
                {
                    return BadRequest("something error");
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOneProduct(int id)
        {
            {
                try
                {
                    var data = _productService.GetOne(id);

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
                var data = _productService.Delete(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromQuery] int id, [FromBody] UpdateProduct updateProduct)
        {
            try
            {
                var data = _productService.Update(id, updateProduct);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }
    }
}