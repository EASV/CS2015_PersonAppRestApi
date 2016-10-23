using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Repository
{
    class WishRepository : AbstractRepository<Wish>
    {
        protected override Wish Create(PersonAppContext db, Wish t)
        {
            return db.Wishes.Add(t);
        }

        protected override Wish Read(PersonAppContext db, int id)
        {
            return db.Wishes.FirstOrDefault(x => x.Id == id);
        }

        protected override List<Wish> Read(PersonAppContext db)
        {
            return db.Wishes.ToList();
        }

        protected override void Update(PersonAppContext db, Wish t)
        {
            db.Entry(t).State = EntityState.Modified;
        }

        protected override void Delete(PersonAppContext db, int id)
        {
            db.Entry(db.Wishes.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
        }
    }
}
