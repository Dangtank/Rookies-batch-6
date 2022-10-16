using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3.Models;
using Day3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;
        private readonly IPersonService _personService;

        public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
        {
            _logger = logger;
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
                    IsGraduated = false
                };
                _personService.Create(person);

                return RedirectToAction("Index");
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
                    DateOfBirth = person.DateOfBirth,
                    BirthPlace = person.BirthPlace,
                    PhoneNumber = person.PhoneNumber,
                };
                ViewData["Index"] = index;

                return View(personUpdate);
            }
            return View();
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
                    person.DateOfBirth = personModelUpdate.DateOfBirth;
                    person.BirthPlace = personModelUpdate.BirthPlace;
                    person.PhoneNumber = personModelUpdate.PhoneNumber;

                    _personService.Update(index, person);
                }
                return RedirectToAction("Index");
            }
            return View("personModel");
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
            ViewData["Index"] = index;
            var person = _personService.GetOne(index);

            if (person != null)
            {
                return View(person);
            }
            return View();
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