using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3.Models;

namespace Day3.Services
{
    public interface IPersonService
    {       
        public List<PersonModel> GetAll();
        public PersonModel GetOne(int index);
        public PersonModel Create(PersonModel personModel);
        public PersonModel Update(int index, PersonModel personModel);
        public PersonModel Delete(int index);
    }
} 