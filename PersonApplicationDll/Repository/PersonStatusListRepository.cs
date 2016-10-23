using System;
using System.Collections.Generic;
using System.Linq;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Repository
{
    class PersonStatusListRepository : IRepository<PersonStatus>
    {
        private static readonly List<PersonStatus> Statuses =
            new List<PersonStatus>
            {
                new PersonStatus {Id = 1, Name = "Away"},
                new PersonStatus {Id = 2, Name = "In Jail"},
                new PersonStatus {Id = 3, Name = "Available"}

            };

        public PersonStatus Create(PersonStatus t)
        {
            throw new NotImplementedException();
        }

        public PersonStatus Read(int id)
        {
            return Statuses.FirstOrDefault(x => x.Id == id);
        }

        public List<PersonStatus> Read()
        {
            return Statuses;
        }

        public PersonStatus Update(PersonStatus t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
