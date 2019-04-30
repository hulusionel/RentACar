using RentACar.Dal.Abstraction;
using RentACar.Dal.Concretes.Context;
using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Concretes.Repo
{
    public class EmployeeRepository : IEmployeeDal
    {
        RentACarContext RentACarContext = new RentACarContext();

        public Employees SelectById(int id)
        {
            return RentACarContext.Employees.Where(x => x.EmployeeID == id).SingleOrDefault();
            //singleOrDefault varsa satır gönder yoksa null gönder
        }

        public bool Delete(Employees entity)
        {
            RentACarContext.Employees.Remove(entity);
            return RentACarContext.SaveChanges() > 0;
        }

        public bool DeletedById(int id)
        {
            var employee = SelectById(id);
            return Delete(employee);
        }
       

        public Employees Insert(Employees entity)
        {
            RentACarContext.Employees.Add(entity);
            RentACarContext.SaveChanges();
            return entity;
        }

        public List<Employees> SelectAll()
        {
            return RentACarContext.Employees.AsNoTracking().ToList();
        }

        public int Update(Employees entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.Employees.AddOrUpdate(entity);
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }

        public Employees EmployeeLogin(string _userName,string _password)
        {
            return RentACarContext.Employees.Where(x => x.UserName == _userName && x.Password == _password).SingleOrDefault();
        }

        public void Dispose()
        {
            RentACarContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
