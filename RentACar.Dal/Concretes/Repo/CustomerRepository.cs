using RentACar.Dal.Abstraction;
using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Concretes.Repo
{
    public class CustomerRepository : ICustomerDal
    {
        RentACarContext RentACarContext = new RentACarContext();

        public Customers SelectById(int id)
        {
            return RentACarContext.Customers.Where(x => x.CustomerID == id).SingleOrDefault();
            //singleOrDefault varsa satır gönder yoksa null gönder
        }

        public bool Delete(Customers entity)
        {
            RentACarContext.Customers.Remove(entity);
            return RentACarContext.SaveChanges() > 0;
        }

        public bool DeletedById(int id)
        {
            var customer = SelectById(id);
            return Delete(customer);
        }
        public Customers CustomerLogin(string UserName, string Password)
        {
            return RentACarContext.Customers.Where(x => x.UserName == UserName && x.Password == Password).SingleOrDefault();
        }


        public Customers Insert(Customers entity)
        {
            RentACarContext.Customers.Add(entity);
            RentACarContext.SaveChanges();
            return entity;
        }

        public List<Customers> SelectAll()
        {
            return RentACarContext.Customers.AsNoTracking().ToList();
        }

        public int Update(Customers entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.Customers.AddOrUpdate(entity);
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }

        public void Dispose()
        {
            RentACarContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Customers> Listele(Expression<Func<Customers, bool>> predicate)
        {
            return RentACarContext.Customers.Where(predicate).ToList();
        }
    }
}
