using Day3.Models;

namespace Day3.Services
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

        public PersonModel Create(PersonModel personModel)
        {
            _people.Add(personModel);

            return personModel;
        }

        public PersonModel Delete(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                _people.RemoveAt(index);

                return person;
            }

            return null;
        }

        public List<PersonModel> GetAll()
        {
            return _people;
        }

        public PersonModel? GetOne(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                return _people[index];
            }

            return null;
        }

        public PersonModel? Update(int index, PersonModel personModel)
        {
            if (index >= 0 && index < _people.Count)
            {
                _people[index] = personModel;

                return personModel;
            }

            return null;
        }
    }
}