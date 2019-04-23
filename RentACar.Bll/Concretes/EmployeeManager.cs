using Interfaces.AbstractModels;
using RentACar.Dal.Abstraction;
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
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            this._employeeDal = employeeDal;
        }

        public bool Delete(Employees entity)
        {
            return _employeeDal.Delete(entity);
        }

        public bool DeletedById(int id)
        {
            return _employeeDal.DeletedById(id);
        }

        public Employees EmployeeLogin(string UserName, string Password)
        {
            try
            {
                if (string.IsNullOrEmpty(UserName.Trim()) || string.IsNullOrEmpty(Password.Trim()))
                {
                    throw new Exception("Kullanıcı Adı veya Parola Boş Geçilemez.");
                }

                var _password = new ToPasswordRepository().Md5(Password);
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
            return _employeeDal.Insert(entity);
        }

        public List<Employees> SelectAll()
        {
            return _employeeDal.SelectAll();
        }

        public Employees SelectById(int id)
        {
            return _employeeDal.SelectById(id);
        }

        public int Update(Employees entity)
        {
            return _employeeDal.Update(entity);
        }
    }
}
