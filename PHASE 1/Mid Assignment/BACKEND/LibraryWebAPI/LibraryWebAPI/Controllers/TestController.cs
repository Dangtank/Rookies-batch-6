// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;

// using LibraryWebAPI.Services;

// namespace LibraryWebAPI.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class LibraryController : ControllerBase
//     {
//         private ILibraryService _LibraryService;

//         public LibraryController(ILibraryService LibraryService)
//         {
//             _LibraryService = LibraryService;
//         }

//         [HttpGet]
//         public ActionResult Index()
//         {
//             return Ok("Library");
//         }

//         [HttpGet("get")]
//         public async Task<ActionResult> Get()
//         {
//             var result = await _LibraryService.Get();
//             return Ok(result);
//         }

//         [HttpPost("post")]
//         public async Task<ActionResult> Post()
//         {
//             await _LibraryService.Add();
//             return Accepted();
//         }
//     }
// }
