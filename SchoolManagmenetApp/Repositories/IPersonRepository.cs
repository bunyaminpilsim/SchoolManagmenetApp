using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        Person GetPersonById(int id);
        List<Person> GetAllPersons();

    }
}
