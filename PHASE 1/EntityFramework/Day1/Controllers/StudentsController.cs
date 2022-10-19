using Microsoft.AspNetCore.Mvc;
using Day1.Models;
using Day1.Services;
using Day1.DTOs;

namespace Day1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public IActionResult Add([FromBody] AddStudentRequest addRequest)
    {
        {
            try
            {
                var data = _studentService.Create(addRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("something error");
            }
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var data = _studentService.GetAll();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest("something error");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var data = _studentService.Delete(id);

            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest("something error");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Edit([FromQuery] int id, [FromBody] StudentUpdateModel studentUpdateModel)
    {
        try
        {
            var data = _studentService.Update(id, studentUpdateModel);

            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest("something error");
        }
    }
}