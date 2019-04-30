using Interfaces;
using Interfaces.AbstractModels;
using RentACar.Dal.Abstraction;
using RentACar.Model.EntityModels;
using RentACar.Dal.Concretes.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Bll.Concretes
{
    public class TransactionManager : ITransactionService
    {
        ITransactionDal _transaction;

        public TransactionManager()
        {
            this._transaction = new TransactionRepository();
        }

        public bool Delete(Transactions entity)
        {
            return _transaction.Delete(entity);
        }

        public bool DeletedById(int id)
        {
            return _transaction.DeletedById(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _transaction.Dispose();
        }

        public Transactions Insert(Transactions entity)
        {
            try
            {
                return _transaction.Insert(entity);                             
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:TransactionBusiness::InsertTransaction::Error occured.", ex);
            }
        }

        public List<Transactions> SelectAll()
        {
           
            try
            {
              return  _transaction.SelectAll();

            }
            catch (Exception)
            {
                throw new Exception("işlemler listelenemedi");
            }
        }

        public Transactions SelectById(int id)
        {
         return   _transaction.SelectById(id);
        }

        public Transactions Update(Transactions entity)
        {
            try
            {            
                _transaction.Update(entity);
                return entity;               
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:TransactionBusiness::UpdateTransaction::Error occured.", ex);
            }
        }


        int day;
        public bool Rent(Transactions transaction,Cars car,Customers customer,DateTime first,DateTime second)
        {
            try
            {
                if (customer.DriveAge >= car.CarDriverAge && customer.DriverType == car.DriverType && customer.LicenceAge >= car.CarLicenceAge && car.Status == true)
                {
                    car.Status = false;
                    ICarDal _car = new CarRepository();
                    _car.Update(car);
                    transaction.CarID = car.CarID;
                    transaction.CustomerID = customer.CustomerID;
                    transaction.BeginDate = first;
                    transaction.DeliveryDate = second;
                    transaction.CurrentKm = car.CurrentKm;
                    transaction.ReturnKm = car.CurrentKm;
                    day = second.Day - first.Day;
                    transaction.RentPrice = car.RentPrice * day;
                    Insert(transaction);
                    return true;
                }
                else
                    return false;

            }
            catch (Exception err)
            {
                throw new Exception("Araç Kiralanamadı"+err);
            } 
           
        }
        public bool GiveBack(Cars car,Customers customer)
        {
            try
            {
                car.CurrentKm = car.CurrentKm + car.DailyKm * day;
                car.Status = true;
                ICarDal _car = new CarRepository();
                _car.Update(car);
                return true;

            }
            catch (Exception)
            {
                throw new Exception("Araç Geri Alınamadı");
            }
        
        }
    }
}
