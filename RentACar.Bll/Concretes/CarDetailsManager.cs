using Interfaces.AbstractModels;
using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RentACar.Dal.Abstraction;
using System.Text;
using System.Threading.Tasks;
using RentACar.Dal.Concretes.Repo;

namespace RentACar.Bll.Concretes
{
    public class CarDetailsManager : ICarDetailsService
    {


        public CarDetail DailyKmControl(int transID, int carID, DateTime date,int Dailykm)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    CarManager carM = new CarManager();
                    Cars car= carM.SelectById(carID); 

                    TransactionManager tranM = new TransactionManager();
                    Transactions tran= tranM.SelectById(transID);

                    //tarih kontrolü yapılmadı
                    
                    ITransactionDal _tran = new TransactionRepository();
                    tran.ReturnKm += Dailykm;
                    _tran.Update(tran);


                    ICarDal _car = new CarRepository();
                    car.CurrentKm += Dailykm;
                    _car.Update(car);


                    if (Dailykm > car.DailyKm)
                    {
                        Console.WriteLine("Günlük max km sınırını aştınız...");
                        int money= (Dailykm - (int)car.DailyKm) * 18 / 100;

                        tran.RentPrice += car.RentPrice +money;
                        _tran.Update(tran);
                    }

                   CarDetail cd= CarDetailsAddTable(car, tran, date, Dailykm);
                    return cd;
                }
            }
            catch (Exception err)
            {
                throw new Exception("Araç Kiralanamadı" + err);
            }
        }

        public CarDetail CarDetailsAddTable(Cars car,Transactions Trans,DateTime date,int dailyKm)
        {
            CarDetail cd = new CarDetail();
            cd.CarID = car.CarID;
            cd.TransactionID = Trans.TransactionID;
            cd.BeginDate = date;
            cd.DailyKm = dailyKm;
            Insert(cd);
            return cd;
        }


        public bool Delete(CarDetail entity)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    return _CarDetailDal.Delete(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public bool DeletedById(int id)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    return _CarDetailDal.DeletedById(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public void Dispose()
        {        
                Dispose(true);
                GC.SuppressFinalize(this);
            
        }
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    if (disposing)
                        _CarDetailDal.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public bool Insert(CarDetail entity)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    _CarDetailDal.Insert(entity);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<CarDetail> Listele(Expression<Func<CarDetail, bool>> predicate)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    return _CarDetailDal.Listele(predicate);
                }
            }
            catch (Exception)
            {

                throw;
            }
   
        }

        public List<CarDetail> SelectAll()
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    return _CarDetailDal.SelectAll();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public CarDetail SelectById(int id)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    return _CarDetailDal.SelectById(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public bool Update(CarDetail entity)
        {
            try
            {
                using (ICarDetailDal _CarDetailDal = new CarDetailRepository())
                {
                    _CarDetailDal.Update(entity);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }         
        }
    }
}
