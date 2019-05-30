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
    public class CompanyRepository : ICompanyDal
    {
        RentACarContext RentACarContext = new RentACarContext();

        public bool Delete(Company entity)
        {
           // RentACarContext.Companies.Remove(entity);
            RentACarContext.Company.Remove(entity);
            return RentACarContext.SaveChanges() > 0;
        }

        public bool DeletedById(int id)
        {
            var _company = SelectById(id);
            return Delete(_company);
        }

        public void Dispose()
        {
            RentACarContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public Company Insert(Company entity)
        {
            RentACarContext.Company.Add(entity);
            RentACarContext.SaveChanges();
            return entity;
        }

        public List<Company> Listele(Expression<Func<Company, bool>> predicate)
        {
            return RentACarContext.Company.Where(predicate).ToList();
        }

        public List<Company> SelectAll()
        {
            return RentACarContext.Company.AsNoTracking().ToList();
        }

        public Company SelectById(int id)
        {
            return RentACarContext.Company.Where(x => x.CompanyID == id).SingleOrDefault();
            //singleOrDefault varsa satır gönder yoksa null gönder
        }

        public int Update(Company entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.Company.AddOrUpdate(entity);
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }
    }
}
