using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RentACar.Model.EntityModels;

namespace RentACar.Dal.Abstraction
{
    public interface ICarDetailDal:IDisposable
    {
        CarDetail Insert(CarDetail entity);
        int Update(CarDetail entity);
        List<CarDetail> SelectAll();
        List<CarDetail> Listele(Expression<Func<CarDetail, bool>> predicate);// Dinamik Filtreleme 
        CarDetail SelectById(int id);
        bool DeletedById(int id);
        bool Delete(CarDetail entity);
    }
}
