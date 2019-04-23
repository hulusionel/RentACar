using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public interface IGenericService<T>
    {
        T Insert(T entity);
        int Update(T entity);
        List<T> SelectAll();
        // List<T> Listele(Expression<Func<T, bool>> predicate); Dinamik Filtreleme 
        T SelectById(int id);
        bool DeletedById(int id);
        bool Delete(T entity);
    }
}
