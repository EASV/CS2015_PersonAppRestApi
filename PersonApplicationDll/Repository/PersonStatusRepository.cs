using System.Collections.Generic;
using System.Linq;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Repository
{
    internal class PersonStatusRepository : AbstractRepository<PersonStatus>
    {
        protected override PersonStatus Create(PersonAppContext db, PersonStatus t)
        {
            return db.PersonStatuses.Add(t);
        }
        protected override PersonStatus Read(PersonAppContext db, int id)
        {
            return db.PersonStatuses.FirstOrDefault(x => x.Id == id);
        }

        protected override List<PersonStatus> Read(PersonAppContext db)
        {
            return db.PersonStatuses.ToList();
        }

        protected override void Update(PersonAppContext db, PersonStatus t)
        {
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
        }

        protected override void Delete(PersonAppContext db, int id)
        {
            var foundEntity = db.PersonStatuses.FirstOrDefault(x => x.Id == id);
            db.Entry(foundEntity).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}
