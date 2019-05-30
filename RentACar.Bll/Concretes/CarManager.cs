using Interfaces.AbstractModels;
using RentACar.Dal.Abstraction;
using RentACar.Dal.Concretes.Repo;
using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RentACar.Bll.Concretes
{
    public class CarManager : ICarService
    {
        //Interface yardımı ile ADO,entity vs istenilen tarafa çevirme kolaylaşıyor
        //ICarDal _carDal;

        //public CarManager()
        //{
        //    this._carDal = new CarRepository();
        //}

        public bool Delete(Cars entity)
        {
            try
            {
                using (ICarDal _carDal = new CarRepository())
                {
                    var deger = _carDal.Delete(entity);
                    if (deger == false)
                    {
                        throw new Exception("Araç silinemedi");
                    }
                    else
                    {
                      
                        ICompanyDal compDal = new CompanyRepository();
                        Company _company = compDal.SelectById(1);
                        _company.NumCars--;
                        compDal.Update(_company);
                        return true;
                    }
                }     
            }
            catch (Exception err)
            {
                throw new Exception("Araç silinemedi" + err.Message);
            }
           
        }

        public bool DeletedById(int id)
        {
            try
            {
                using (ICarDal _carDal = new CarRepository())
                {
                    var car = SelectById(id);//var ise nesne döndürür
                    if (car == null)
                        throw new Exception("Araç silinemedi");
                    else
                    {
                        Delete(car);
                        return true;
                    }
                }
                              
            }
            catch (Exception err)
            {

                throw new Exception("Araç silinemedi" + err.Message);
            } 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            using (ICarDal _carDal = new CarRepository())
            {
                if (disposing)
                    _carDal.Dispose();
            }
            
        }

        public bool Insert(Cars entity)
        {
            try
            {
                using (ICarDal _carDal = new CarRepository())
                {
                    var deger = _carDal.Insert(entity);
                    if (deger == null)
                    {
                        return false;
                    }
                    else
                    {
                        ICompanyDal compDal = new CompanyRepository();
                        Company _company = compDal.SelectById(1);
                        _company.NumCars++;
                        compDal.Update(_company);
                        return true;
                    }
                }
                
            }
            catch (Exception err)
            {

                throw new Exception("Araç Eklenemedi" + err.Message);
            }

        }

        public List<Cars> SelectAll()
        {
            try
            {
                using (ICarDal _carDal= new CarRepository())
                {
                    return _carDal.SelectAll();
                }
                
            }
            catch (Exception err)
            {

                throw new Exception("Araç Listelenemedi" + err.Message);
            }
           
        }

        public Cars SelectById(int id)
        {
            try
            {
                using (ICarDal _carDal = new CarRepository())
                {
                    return _carDal.SelectById(id);
                }
                
            }
            catch (Exception err)
            {

                throw new Exception("Araç Seçilemedi" + err.Message);
            }
            
        }

        public bool Update(Cars entity)
        {
            try
            {
                using (ICarDal _carDal = new CarRepository())
                {
                    _carDal.Update(entity);
                    return true;
                }
            }
            catch (Exception err)
            {
                throw new Exception("Araç Seçilemedi" + err.Message);
            }
        }

        public List<Cars> Listele(Expression<Func<Cars, bool>> predicate)
        {
            using (ICarDal _carDal = new CarRepository())
            {
                return _carDal.Listele(predicate);
            }
           
           
        }
    }
}
