using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll
{
    public interface IRepository<T>
    {
        //Create
        T Create(T t);

        //Read
        T Read(int id);
        List<T> Read();

        //Update
        T Update(T t);

        //Delete
        bool Delete(int id);
    }
}
