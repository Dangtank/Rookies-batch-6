using Day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        private static List<PersonModel> _people = new List<PersonModel>
        {
            new PersonModel
            {
                FirstName = "Giang",
                LastName = "Vu Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new PersonModel
            {
                FirstName = "Kien",
                LastName = "Mai trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Thanh Hoa",
                IsGraduated = false
            },
            new PersonModel
            {
                FirstName = "Kiet",
                LastName = "Hoang Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Nam Dinh",
                IsGraduated = false
            },
            new PersonModel
            {
                FirstName = "Trong",
                LastName = "Le Quy",
                Gender = "Female",
                DateOfBirth = new DateTime(2003, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Hung Yen",
                IsGraduated = false
            },
            new PersonModel
            {
                FirstName = "Hieu",
                LastName = "Hoang Trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new PersonModel
            {
                FirstName = "Hoan",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                PhoneNumber = "",
                BirthPlace = "Quang Ninh",
                IsGraduated = false
            },
            new PersonModel
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
            return View(_people);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(PersonModelCreate personModelCreate)
        {
            if (ModelState.IsValid)
            {
                var person = new PersonModel
                {
                    FirstName = personModelCreate.FirstName,
                    LastName = personModelCreate.LastName,
                    Gender = personModelCreate.Gender,
                    DateOfBirth = personModelCreate.DateOfBirth,
                    BirthPlace = personModelCreate.BirthPlace,
                    PhoneNumber = personModelCreate.PhoneNumber,
                    IsGraduated = true
                };
                _people.Add(person);

                return RedirectToAction("Index");
            }

            return View(personModelCreate);
        }

        [HttpGet]

        public IActionResult Edit(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                var personModelUpdate = new PersonModelUpdate
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    DateOfBirth = person.DateOfBirth,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber,
                };

                return View(personModelUpdate);
            }

            return View();
        }

        [HttpPost]

        public IActionResult Update(int index, PersonModelUpdate personModelUpdate)
        {
            if (ModelState.IsValid)
            {
                if (index >= 0 && index < _people.Count)
                {
                    var person = _people[index];
                    person.FirstName = personModelUpdate.FirstName;
                    person.LastName = personModelUpdate.LastName;
                    person.PhoneNumber = personModelUpdate.PhoneNumber;
                    person.BirthPlace = personModelUpdate.BirthPlace;
                }

                return RedirectToAction("Index");
            }
            
            return View(personModelUpdate);
        }

        [HttpPost]

        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                _people.RemoveAt(index);
            }

            return RedirectToAction("Index");
        }
    }
}