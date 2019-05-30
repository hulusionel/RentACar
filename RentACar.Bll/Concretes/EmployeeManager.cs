using Interfaces.AbstractModels;
using RentACar.Dal.Abstraction;
using RentACar.Dal.Concretes.Repo;
using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Bll.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        //IEmployeeDal _employeeDal;
        //public EmployeeManager()
        //{
        //    this._employeeDal = new EmployeeRepository();
        //}

        public bool Delete(Employees entity)
        {
            try
            {
                using (IEmployeeDal _employeeDal = new EmployeeRepository())
                {
                    _employeeDal.Delete(entity);
                    return true;
                }
                
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
                using (IEmployeeDal _employeeDal = new EmployeeRepository())
                {
                    return _employeeDal.DeletedById(id);
                }
               
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
            using (IEmployeeDal _employeeDal = new EmployeeRepository())
            {
                if (disposing)
                    _employeeDal.Dispose();
            }
               
        }

        public Employees EmployeeLogin(string UserName, string Password)
        {
            try
            {
                using (IEmployeeDal _employeeDal = new EmployeeRepository())
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
                   
            }
            catch (Exception err)
            {
                throw new Exception("Giriş Hatası Oluştu"+err.Message);
            }          
        }

        public bool Insert(Employees entity)
        {
            try
            {
                using (IEmployeeDal _employeeDal = new EmployeeRepository())
                {
                    entity.Password = new ToPassword().Md5(entity.Password);
                    _employeeDal.Insert(entity);
                    return true;
                }
                   
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
                using (IEmployeeDal _employeeDal = new EmployeeRepository())
                {
                    return _employeeDal.SelectAll();
                }                  
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
                using (IEmployeeDal _employeeDal = new EmployeeRepository())
                {
                    return _employeeDal.SelectById(id);
                }
                    
            }
            catch (Exception err)
            {

                throw new Exception("Employee Seçilemedi " + err.Message);
            }
           
        }

        public bool Update(Employees entity)
        {
            try
            {
                using (IEmployeeDal _employeeDal = new EmployeeRepository())
                {
                    _employeeDal.Update(entity);
                    return true;
                }                
            }
            catch (Exception err)
            {
                throw new Exception("Employee Güncellenemedi " + err.Message);
            }
          
        }

        public List<Employees> Listele(Expression<Func<Employees, bool>> predicate)
        {
            using (IEmployeeDal _employeeDal = new EmployeeRepository())
            {
                return _employeeDal.Listele(predicate);
            }
               
        }
    }
}
