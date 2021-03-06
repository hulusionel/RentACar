﻿using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Abstraction
{
   public interface ICustomerDal:IDisposable
    {
        Customers Insert(Customers entity);
        int Update(Customers entity);
        List<Customers> SelectAll();
        List<Customers> Listele(Expression<Func<Customers, bool>> predicate); //Dinamik Filtreleme 
        Customers SelectById(int id);
        bool DeletedById(int id);
        bool Delete(Customers entity);
        Customers CustomerLogin(string UserName, string Password);
    }
}
