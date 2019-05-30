using RentACar.Dal.Abstraction;
using RentACar.Dal.Concretes;
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
    public class CarRepository : ICarDal
    {
         RentACarContext RentACarContext = new RentACarContext();

        public Cars SelectById(int id)
        {
            return RentACarContext.Cars.Where(x => x.CarID == id).SingleOrDefault();
            //singleOrDefault varsa satır gönder yoksa null gönder
        }

        public bool Delete(Cars entity)
        {
            RentACarContext.Cars.Remove(entity);            
            return RentACarContext.SaveChanges()>0;         
        }

        public bool DeletedById(int id)
        {
            var car = SelectById(id);
            return Delete(car);
        }
     
        public Cars Insert(Cars entity)
        {
            RentACarContext.Cars.Add(entity);           
            RentACarContext.SaveChanges();
            return entity;
        }

        public List<Cars> SelectAll()
        {
            return RentACarContext.Cars.AsNoTracking().ToList();
            //asnotracking Her zaman ilk db ye bakar cache'den yanlış veri getirmez
        }

        public int Update(Cars entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.Cars.AddOrUpdate(entity);
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }

        public void Dispose()
        {
            RentACarContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<Cars> Listele(Expression<Func<Cars, bool>> predicate)
        {
            return RentACarContext.Cars.Where(predicate).ToList();
        }
    }
}
