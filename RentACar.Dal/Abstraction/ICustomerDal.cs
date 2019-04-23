using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstraction
{
   public interface ICustomerDal
    {
        Customers Insert(Customers entity);
        int Update(Customers entity);
        List<Customers> SelectAll();
        // List<T> Listele(Expression<Func<T, bool>> predicate); Dinamik Filtreleme 
        Customers SelectById(int id);
        bool DeletedById(int id);
        bool Delete(Customers entity);
    }
}
