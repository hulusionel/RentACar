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
    public class CompanyRepository : ICompanyDal
    {
        RentACarContext RentACarContext = new RentACarContext();
        public bool Delete(Company entity)
        {
            RentACarContext.Companies.Remove(entity);
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
            RentACarContext.Companies.Add(entity);
            RentACarContext.SaveChanges();
            return entity;
        }

        public List<Company> SelectAll()
        {
            return RentACarContext.Companies.AsNoTracking().ToList();
        }

        public Company SelectById(int id)
        {
            return RentACarContext.Companies.Where(x => x.CompanyID == id).SingleOrDefault();
            //singleOrDefault varsa satır gönder yoksa null gönder
        }

        public int Update(Company entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.Companies.AddOrUpdate(entity);
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }
    }
}
