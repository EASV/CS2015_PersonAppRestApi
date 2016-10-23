using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Entities;
using PersonApplicationDll.Repository;

namespace PersonApplicationDll
{
    public class DllFacade
    {
        public IRepository<Person> GetPersonRepository()
        {
            return new PersonRepository();
        }

        public IRepository<PersonStatus> GetPersonStatusRepository()
        {
           return new PersonStatusRepository();
        }

        public IRepository<Wish> GetWishRepository()
        {
            return new WishRepository();
        }
    }
}
