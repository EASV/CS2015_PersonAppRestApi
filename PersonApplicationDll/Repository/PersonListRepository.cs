using System.Collections.Generic;
using System.Linq;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Repository
{

    class PersonListRepository : IRepository<Person>
    {
        static PersonStatusListRepository _psm = new PersonStatusListRepository();
        private static int PersonId = 1;
        
        private static readonly List<Person> Persons =
            new List<Person>
            {  new Person { Id = PersonId ++, Name = "Lars", Status = _psm.Read(1)},
               new Person { Id = PersonId ++, Name = "Bob", Status =  _psm.Read(2)},
               new Person { Id = PersonId ++, Name = "Joe", Status =  _psm.Read(3)}
            };
        
        public Person Create(Person person)
        {
            var personStatus = _psm.Read(person.Status.Id);
            person.Status = personStatus;
            person.Id = PersonId++;
            Persons.Add(person);
            return person;
        }

        public Person Read(int id)
        {
            return Persons.FirstOrDefault(x => x.Id == id);
        }

        public List<Person> Read()
        {
            return Persons;
        }

        public Person Update(Person p)
        {
            var personToEdit = Persons.FirstOrDefault(x => x.Id == p.Id);
            if (personToEdit != null)
            {
                personToEdit.Name = p.Name;
                personToEdit.Status = _psm.Read(p.Status.Id);
            }
            return personToEdit;
            
        }

        public bool Delete(int id)
        {
            return 1 == Persons.RemoveAll(x => x.Id == id);
        }
    }
}
