using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2.Helpers;
using Day2.Models;
using Day2.Services;

namespace Day2.Services
{
    public class PersonService : IPersonService
    {
        private static List<PersonModel> _people = new List<PersonModel>
        {
             new PersonModel
            {
                FirstName = "Giang",
                LastName = "Vu Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                BirthPlace = "Phu Tho",
            },
            new PersonModel
            {
                FirstName = "Kien",
                LastName = "Mai trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 3, 15),
                BirthPlace = "Thanh Hoa",
            },
            new PersonModel
            {
                FirstName = "Kiet",
                LastName = "Hoang Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 15),
                BirthPlace = "Nam Dinh",
            },
            new PersonModel
            {
                FirstName = "Trong",
                LastName = "Le Quy",
                Gender = "Female",
                DateOfBirth = new DateTime(2003, 3, 15),
                BirthPlace = "Hung Yen",
            },
            new PersonModel
            {
                FirstName = "Hieu",
                LastName = "Hoang Trung",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 15),
                BirthPlace = "Ha Noi",
            },
            new PersonModel
            {
                FirstName = "Hoan",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                BirthPlace = "Quang Ninh",
            },
            new PersonModel
            {
                FirstName = "Anh",
                LastName = "Dang Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 3, 15),
                BirthPlace = "Ninh Binh",
            },
        };

        public List<PersonModel> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
            }
        }

        public PersonModel Create(PersonModel personModel)
        {
            var newPerson = new PersonModel
            {
                Id = Guid.NewGuid(),
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Gender = personModel.Gender,
                DateOfBirth = personModel.DateOfBirth,
                BirthPlace = personModel.BirthPlace,
            };

            _people.Add(newPerson);

            return newPerson;
        }
        public List<PersonModel> GetAll()
        {
            return _people;
        }

        public PersonModel Delete(Guid id)
        {
            var deleteTask = _people.FirstOrDefault(i => i.Id == id);

            if (deleteTask != null)
            {
                _people.Remove(deleteTask);

                return deleteTask;
            }
            return null;
        }

        public PersonModel? Update(Guid id, PersonModel personModel)
        {
            var personUpdate = _people.FirstOrDefault(i => i.Id == id);

            if (personUpdate != null)
            {
                personUpdate.FirstName = personModel.FirstName;
                personUpdate.LastName = personModel.LastName;
                personUpdate.Gender = personModel.Gender;
                personUpdate.BirthPlace = personModel.BirthPlace;
                personUpdate.DateOfBirth = personModel.DateOfBirth;

                return personUpdate;
            }
            return null;
        }

        public IEnumerable<PersonModel> Filter(FilterModel filterModel)
        {
            var filterPeople = People;

            #region Filtering

            var name = filterModel.Name;
            var gender = filterModel.Gender;
            var birthPlace = filterModel.BirthPlace;

            if (!String.IsNullOrEmpty(name))
            {
                filterPeople = filterPeople.Where(s => s.FirstName.Contains(name)
                                       || s.LastName.Contains(name)).ToList();
            }

            if (!String.IsNullOrEmpty(gender))
            {
                filterPeople = filterPeople.Where(s => s.Gender.Contains(gender)).ToList();
            }

            if (!String.IsNullOrEmpty(gender))
            {
                filterPeople = filterPeople.Where(s => s.BirthPlace.Contains(birthPlace)).ToList();
            }

            #endregion

            #region Paging

            filterPeople = FilterHelper.GetPage(filterPeople, filterModel.PageIndex-1, filterModel.PageSize).ToList();

            #endregion

            return filterPeople;
        }
    }
}
