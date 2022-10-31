using Day3.Models;
using Day3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    public class RookiesController : Controller
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            var data = _personService.GetAll();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonModelCreate personModelCreate)
        {
            try
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
                    };
                    _personService.Create(person);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(personModelCreate);
            }

            return View(personModelCreate);
        }

        [HttpGet]
        public IActionResult Edit(int index)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
                var personUpdate = new PersonModelUpdate
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber,
                };
                ViewData["index"] = index;

                return View(personUpdate);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Update(int index, PersonModelUpdate personModelUpdate)
        {
            if (ModelState.IsValid)
            {
                var person = _personService.GetOne(index);

                if (person != null)
                {
                    person.FirstName = personModelUpdate.FirstName;
                    person.LastName = personModelUpdate.LastName;
                    person.Gender = personModelUpdate.Gender;
                    person.BirthPlace = personModelUpdate.BirthPlace;
                    person.PhoneNumber = personModelUpdate.PhoneNumber;

                    _personService.Update(index, person);
                }
                return RedirectToAction("Index");
            }

            return View(personModelUpdate);
        }

        [HttpPost]
        public IActionResult Delete(int index)
        {
            var result = _personService.Delete(index);

            if (result == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int index)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
                var model = new PersonModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber,
                };
                ViewData["index"] = index;

                return View(model);
            }
            
            return Content("NotFound");
        }

        [HttpPost]
        public IActionResult DeleteAndRedirectToResultPage(int index)
        {
            var person = _personService.GetOne(index);

            if (person == null) return NotFound();

            HttpContext.Session.SetString("DeletePersonName", person.FullName);
            _personService.Delete(index);

            return RedirectToAction("DeleteResult");
        }

        public IActionResult DeleteResult()
        {
            return View();
        }
    }
}