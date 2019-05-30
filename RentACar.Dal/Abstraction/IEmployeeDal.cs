using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstraction
{
    public interface IEmployeeDal:IDisposable
    {
        Employees Insert(Employees entity);
        int Update(Employees entity);
        List<Employees> SelectAll();
        List<Employees> Listele(Expression<Func<Employees, bool>> predicate); //Dinamik Filtreleme 
        Employees SelectById(int id);
        bool DeletedById(int id);
        bool Delete(Employees entity);
        Employees EmployeeLogin(string UserName, string Password);
    }
}
