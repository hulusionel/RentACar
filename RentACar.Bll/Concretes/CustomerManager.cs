using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Interfaces.AbstractModels;
using RentACar.Dal.Abstraction;
using RentACar.Dal.Concretes.Repo;
using RentACar.Model.EntityModels;

namespace RentACar.Bll.Concretes
{
    public class CustomerManager : ICustomerService
    {
        //ICustomerDal _customerDal;

        //public CustomerManager()
        //{
        //    this._customerDal = new CustomerRepository();
        //}

        public bool Delete(Customers entity)
        {
            using (ICustomerDal _customerDal = new CustomerRepository())
            {
                return _customerDal.Delete(entity);
            }     
        }

        public bool DeletedById(int id)
        {
            try
            {
                using (ICustomerDal _customerDal = new CustomerRepository())
                {
                    return _customerDal.DeletedById(id);
                }
                    
            }
            catch (Exception)
            {

                throw new Exception("Giriş Hatası Oluştu" );
            }
           
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            using (ICustomerDal _customerDal = new CustomerRepository())
            {
                if (disposing)
                    _customerDal.Dispose();
            }
               
        }

        public bool Insert(Customers entity)
        {
            try
            {
                using (ICustomerDal _customerDal = new CustomerRepository())
                {
                    entity.Password = new ToPassword().Md5(entity.Password);
                    _customerDal.Insert(entity);
                    return true;
                }                  
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public Customers CustomerLogin(string UserName, string Password)
        {
            try
            {
                using (ICustomerDal _customerDal = new CustomerRepository())
                {
                    if (string.IsNullOrEmpty(UserName.Trim()) || string.IsNullOrEmpty(Password.Trim()))
                    {
                        throw new Exception("Müşteri Adı veya Parola Boş Geçilemez.");
                    }
                    var _password = new ToPassword().Md5(Password);//parola şifre dönüştürme
                    var Emp = _customerDal.CustomerLogin(UserName, _password);
                    if (Emp == null)
                        throw new Exception("Müşteri Adı veya Parola Hatalı");
                    else
                        return Emp;
                }
                    
            }
            catch (Exception err)
            {
                throw new Exception("Giriş Hatası Oluştu" + err.Message);
            }
        }

        public List<Customers> SelectAll()
        {
            try
            {
                using (ICustomerDal _customerDal = new CustomerRepository())
                {
                    return _customerDal.SelectAll();
                }
            }
            catch (Exception)
            {

                throw new Exception("Listelenemedi" );
            }
           
        }

        public Customers SelectById(int id)
        {
            try
            {
                using (ICustomerDal _customerDal = new CustomerRepository())
                {
                    return _customerDal.SelectById(id);
                }                 
            }
            catch (Exception)
            {
                throw new Exception("Seçilemedi");
            }
           
        }

        public bool Update(Customers entity)
        {
            try
            {
                using (ICustomerDal _customerDal = new CustomerRepository())
                {
                    _customerDal.Update(entity);
                    return true;
                }                   
            }
            catch (Exception)
            {
                throw new Exception("Seçilemedi");
            }
           
        }

        public List<Customers> Listele(Expression<Func<Customers, bool>> predicate)
        {
            using (ICustomerDal _customerDal = new CustomerRepository())
            {
                return _customerDal.Listele(predicate);
            }             
        }
    }
}
