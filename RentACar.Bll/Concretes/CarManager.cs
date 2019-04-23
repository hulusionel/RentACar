using Interfaces.AbstractModels;
using RentACar.Dal.Abstraction;
using RentACar.Model.EntityModels;
using System.Collections.Generic;

namespace RentACar.Bll.Concretes
{
    public class CarManager : ICarService
    {
        //Interface yardımı ile ADO,entity vs istenilen tarafa çevirme kolaylaşıyor
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        public bool Delete(Cars entity)
        {
            return _carDal.Delete(entity);
        }

        public bool DeletedById(int id)
        {
            return _carDal.DeletedById(id);
        }

        public Cars Insert(Cars entity)
        {
            return _carDal.Insert(entity);
        }

        public List<Cars> SelectAll()
        {
            return _carDal.SelectAll();
        }

        public Cars SelectById(int id)
        {
            return _carDal.SelectById(id);
        }

        public int Update(Cars entity)
        {
            return _carDal.Update(entity);
        }
    }
}
