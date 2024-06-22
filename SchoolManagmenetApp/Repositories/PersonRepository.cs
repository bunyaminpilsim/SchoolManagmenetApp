using SchoolManagmenetApp.Models;

namespace SchoolManagmenetApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        List<Person> _persons=new List<Person>();
        public void AddPerson(Person person)
        {
           _persons.Add(person);
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
        }

        public List<Person> GetAllPersons()
        {
            return _persons;
        }

        public Person GetPersonById(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            return person;
        }

        public List<Person> GetStudent()
        {
            var student = _persons.Where(x => x.Role.Name == "Öğrenci").ToList();
            return student;
        }
        public List<Person> GetTeacher()
        {
            var teacher = _persons.Where(x => x.Role.Name == "Öğretmen").ToList();
            return teacher;
        }

        public void UpdatePerson(Person person)
        {
            var existingPerson=GetPersonById(person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Gender = person.Gender;
                existingPerson.Age = person.Age;
                existingPerson.RoleId = person.RoleId;
                existingPerson.Role=person.Role;
                existingPerson.BranchId = person.BranchId;
                existingPerson.Branch=person.Branch;
                existingPerson.ImgPath = person.ImgPath;
            }
        }
    }
}
