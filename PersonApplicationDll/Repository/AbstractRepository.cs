using System;
using System.Collections.Generic;
using PersonApplicationDll.Context;

namespace PersonApplicationDll.Repository
{
    internal abstract class AbstractRepository<T> : IRepository<T>

{
    public T Create(T t)
    {
        using (var db = new PersonAppContext())
        {
            var added = Create(db, t);
            db.SaveChanges();
            return added;
        }
    }

    protected abstract T Create(PersonAppContext db, T t);

    public T Read(int id)
    {
        using (var db = new PersonAppContext())
        {
            return Read(db, id);
        }
    }

    protected abstract T Read(PersonAppContext db, int id);

    public List<T> Read()
    {
        using (var db = new PersonAppContext())
        {
            return Read(db);
        }
    }

    protected abstract List<T> Read(PersonAppContext db);

    public T Update(T t)
    {
        using (var db = new PersonAppContext())
        {
            Update(db, t);
            db.SaveChanges();
            return t;
        }
    }

    protected abstract void Update(PersonAppContext db, T t);

    public bool Delete(int id)
    {
        using (var db = new PersonAppContext())
        {

            if (Read(db, id) == null) return false;
            try
            {
                Delete(db, id);
                db.SaveChanges();
            }
                catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return Read(db, id) == null;
        }
    }

    protected abstract void Delete(PersonAppContext db, int id);
}
}
