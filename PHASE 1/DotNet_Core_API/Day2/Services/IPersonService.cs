using Day2.Models;

namespace Day2.Services
{
    public interface IPersonService
    {       
        public PersonModel Create(PersonModel personModel);
        public PersonModel Update(Guid id, PersonModel personModel);
        public PersonModel Delete(Guid id);
        public List<PersonModel> GetAll();
        public IEnumerable<PersonModel> Filter(FilterModel filterModel);
    }
} 