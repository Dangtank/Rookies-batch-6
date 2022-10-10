using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using CsvHelper;
using DAY1.Models;
namespace DAY1.Controllers
{
    [Route("nashtech/rookies")]
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        private static List<Person> _people = new List<Person>
        {
            new Person
            {
                FirstName = "Giang",
                LastName = "Vu Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Person
            {
                FirstName = "Kien",
                LastName = "Mai trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Thanh Hoa",
                IsGraduated = false
            },
            new Person
            {
                FirstName = "Kiet",
                LastName = "Hoang Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Nam Dinh",
                IsGraduated = false
            },
            new Person
            {
                FirstName = "Trong",
                LastName = "Le Quy",
                Gender = "Female",
                DateOfBirth = new DateTime(2003, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Hung Yen",
                IsGraduated = false
            },
            new Person
            {
                FirstName = "Hieu",
                LastName = "Hoang Trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person
            {
                FirstName = "Hoan",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Quang Ninh",
                IsGraduated = false
            },
            new Person
            {
                FirstName = "Anh",
                LastName = "Dang Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Ninh Binh",
                IsGraduated = false
            },
        };

        public IActionResult Index()
        {
            return Json(_people);
        }

        #region #1
        [Route("male-member")]
        public IActionResult GetMaleMember()
        {
            var data = _people.FindAll(p => p.Gender.Equals("Male")).ToList();

            return new JsonResult(data);
        }
        #endregion
       
        #region #2
        [Route("/oldest-member")]
        public IActionResult GetOldestMember()
        {
            var maxAge = _people.Max(p => p.Age);
            var data = _people.FirstOrDefault(p => p.Age == maxAge);

            return new JsonResult(data);
        }
        #endregion
        
        #region #3
        [Route("fullname-member")]
        public IActionResult GetFullNameMember()
        {
            var data = _people.Select(p => p.FullName).ToList();

            return new JsonResult(data);
        }
        #endregion

        #region #4
        [Route("filter-member")]
        public IActionResult GetMemberByBirthYear(int year, string type)
        {
            switch (type)
            {
                case "equal":
                    return Json(_people.Where(p => p.DateOfBirth.Year == year).ToList());
                case "greater":
                    return Json(_people.Where(p => p.DateOfBirth.Year > year).ToList());
                case "less":
                    return Json(_people.Where(p => p.DateOfBirth.Year < year).ToList());
                default:
                    return Json(null);
            }
        }
        [Route("yearequal-member")]
        public IActionResult GetMemberByBirthYearEqual(int year)
        {
            return RedirectToAction("GetMemberByBirthYearEqual", new { year = 2000, type = "equal" });
        }
        [Route("yeargreater-member")]
        public IActionResult GetMemberByBirthYearGreater(int year)
        {
            return RedirectToAction("GetMemberByBirthYearEqual", new { year = 2000, type = "greater" });
        }

        [Route("yearless-member")]
        public IActionResult GetMemberByBirthYearLess(int year)
        {
            return RedirectToAction("GetMemberByBirthYearEqual", new { year = 2000, type = "less" });
        }
        #endregion

        #region #5
        private byte[] WriterCsvtoMemory(IEnumerable<Person> people)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture))
            {
                csWriter.WriteRecords(people);
                streamWriter.Flush();

                return memoryStream.ToArray();
            }
        }

        [Route("export")]
        public IActionResult Export()
        {
            var result = WriterCsvtoMemory(_people);
            var stream = new MemoryStream(result);

            return new FileStreamResult(stream, "text/csv") { FileDownloadName = "ListOfPerson.csv" };
        }
        #endregion

    }
}
