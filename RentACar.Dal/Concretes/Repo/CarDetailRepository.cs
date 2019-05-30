using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RentACar.Dal.Abstraction;
using RentACar.Model.EntityModels;

namespace RentACar.Dal.Concretes.Repo
{
    public class CarDetailRepository : ICarDetailDal
    {
        RentACarContext RentACarContext = new RentACarContext();

        public bool Delete(CarDetail entity)
        {
            RentACarContext.CarDetail.Remove(entity);
            return RentACarContext.SaveChanges() > 0;
        }

        public bool DeletedById(int id)
        {
            var detail = SelectById(id);
            return Delete(detail);
        }

        public void Dispose()
        {
            RentACarContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public CarDetail Insert(CarDetail entity)
        {
            RentACarContext.CarDetail.Add(entity);
            RentACarContext.SaveChanges();
            return entity;
        }

        public List<CarDetail> Listele(Expression<Func<CarDetail, bool>> predicate)
        {
            return RentACarContext.CarDetail.Where(predicate).ToList();
        }

        public List<CarDetail> SelectAll()
        {
            return RentACarContext.CarDetail.AsNoTracking().ToList();
            //asnotracking Her zaman ilk db ye bakar cache'den yanlış veri getirmez
        }

        public CarDetail SelectById(int id)
        {
            return RentACarContext.CarDetail.Where(x => x.CarDetailsID == id).SingleOrDefault();
            //singleOrDefault varsa satır gönder yoksa null gönder
        }

        public int Update(CarDetail entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.CarDetail.AddOrUpdate(entity);
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }
    }
}
