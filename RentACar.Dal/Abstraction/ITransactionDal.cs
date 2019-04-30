using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstraction
{
   public  interface ITransactionDal:IDisposable
    {
        Transactions Insert(Transactions entity);
        int Update(Transactions entity);
        List<Transactions> SelectAll();
        // List<T> Listele(Expression<Func<T, bool>> predicate); Dinamik Filtreleme 
        Transactions SelectById(int id);
        bool DeletedById(int id);
        bool Delete(Transactions entity);
    }
}
