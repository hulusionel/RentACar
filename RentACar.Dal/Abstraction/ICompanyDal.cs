using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstraction
{
   public  interface ICompanyDal:IDisposable
    {
        Company Insert(Company entity);
        int Update(Company entity);
        List<Company> SelectAll();
        List<Company> Listele(Expression<Func<Company, bool>> predicate); //Dinamik Filtreleme 
        Company SelectById(int id);
        bool DeletedById(int id);
        bool Delete(Company entity);
    }
}
