using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Repository
{
    class PersonRepository : AbstractRepository<Person>
    {
        protected override Person Create(PersonAppContext db, Person t)
        {
            foreach (var w in t.Wishes)
            {
                db.Entry(w).State = EntityState.Unchanged;
            }
            return db.Persons.Add(t);
        }

        protected override Person Read(PersonAppContext db, int id)
        {
            return db.Persons.Include(x => x.Status).Include(x => x.Wishes).FirstOrDefault(x => x.Id == id);
        }

        protected override List<Person> Read(PersonAppContext db)
        {
            return db.Persons.Include(x => x.Status).Include(x => x.Wishes).ToList();
        }

        protected override void Update(PersonAppContext db, Person t)
        {
            var existingPerson = db.Persons
                    .Include(x => x.Wishes).FirstOrDefault(s => s.Id == t.Id);
            if (existingPerson == null) return;
            {
                var wishesToRemove = new List<Wish>(existingPerson.Wishes.Where(i => t.Wishes.FirstOrDefault(x => x.Id == i.Id) == null));
                var wishesToAdd = new List<Wish>(t.Wishes.Where(i => existingPerson.Wishes.FirstOrDefault(x => x.Id == i.Id) == null));

                foreach (var wish in wishesToRemove)
                {
                    existingPerson.Wishes.Remove(wish);
                }

                foreach (var wish in wishesToAdd)
                {
                    db.Wishes.Attach(wish);
                    existingPerson.Wishes.Add(wish);
                }

                existingPerson.Name = t.Name;
                existingPerson.PersonStatusId = t.PersonStatusId;

                db.Entry(existingPerson).State = EntityState.Modified;
            }

        }

        protected override void Delete(PersonAppContext db, int id)
        {
            var foundEntity = Read(db, id);
            db.Entry(foundEntity).State = EntityState.Deleted;
        }
    }
}
