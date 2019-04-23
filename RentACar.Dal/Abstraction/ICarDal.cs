using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstraction
{
    public interface ICarDal
    {
        Cars Insert(Cars entity);
        int Update(Cars entity);
        List<Cars> SelectAll();
        // List<T> Listele(Expression<Func<T, bool>> predicate); Dinamik Filtreleme 
        Cars SelectById(int id);
        bool DeletedById(int id);
        bool Delete(Cars entity);
    }
}
