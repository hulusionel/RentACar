using Interfaces.AbstractModels;
using RentACar.Dal.Abstraction;
using RentACar.Dal.Concretes.Repo;
using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Bll.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager()
        {
            this._employeeDal = new EmployeeRepository();
        }

        public bool Delete(Employees entity)
        {
            try
            {
                return _employeeDal.Delete(entity);
            }
            catch (Exception err)
            {
                throw new Exception("Employee silinemedi" + err.Message);
            }
           
        }

        public bool DeletedById(int id)
        {
            try
            {
                return _employeeDal.DeletedById(id);
            }
            catch (Exception err)
            {
                throw new Exception("Employee silinemedi" + err.Message);
            }
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _employeeDal.Dispose();
        }

        public Employees EmployeeLogin(string UserName, string Password)
        {
            try
            {
                if (string.IsNullOrEmpty(UserName.Trim()) || string.IsNullOrEmpty(Password.Trim()))
                {
                    throw new Exception("Kullanıcı Adı veya Parola Boş Geçilemez.");
                }
                var _password = new ToPassword().Md5(Password);//parola şifre dönüştürme
                var Emp = _employeeDal.EmployeeLogin(UserName, _password);
                if (Emp == null)
                    throw new Exception("Kullanıcı Adı veya Parola Hatalı");
                else
                    return Emp;
            }
            catch (Exception err)
            {
                throw new Exception("Giriş Hatası Oluştu"+err.Message);
            }          
        }

        public Employees Insert(Employees entity)
        {
            try
            {
                entity.Password = new ToPassword().Md5(entity.Password);
                return _employeeDal.Insert(entity);
            }
            catch (Exception err)
            {
                throw new Exception("Employee eklenemedi " + err.Message);
            }
           
        }

        public List<Employees> SelectAll()
        {
            try
            {
                return _employeeDal.SelectAll();
            }
            catch (Exception err)
            {

                throw new Exception("Employee Listelenemedi " + err.Message);
            }
            
        }

        public Employees SelectById(int id)
        {
            try
            {
                return _employeeDal.SelectById(id);
            }
            catch (Exception err)
            {

                throw new Exception("Employee Seçilemedi " + err.Message);
            }
           
        }

        public Employees Update(Employees entity)
        {
            try
            {
                //şifre hash yap
                _employeeDal.Update(entity);
                return entity;
            }
            catch (Exception err)
            {

                throw new Exception("Employee Güncellenemedi " + err.Message);
            }
          
        }
    }
}
