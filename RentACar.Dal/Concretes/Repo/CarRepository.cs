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
        }

        public int Update(Cars entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.Cars.AddOrUpdate();
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }
    }
}
