using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class SqlRepository<T>
    {
        public abstract List<T> ReadAll();
        public abstract T ReadById(int id);
        public abstract bool Create(T t);
        public abstract bool Update(T t);
        public abstract bool Delete(int id);
        public abstract void Restore(T t);       
    }
}
