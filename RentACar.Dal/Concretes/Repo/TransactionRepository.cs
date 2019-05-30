using RentACar.Dal.Abstraction;
using RentACar.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dal.Concretes.Repo
{
    public class TransactionRepository : ITransactionDal
    {
        RentACarContext RentACarContext = new RentACarContext();

        public bool Delete(Transactions entity)
        {
            RentACarContext.Transactions.Remove(entity);
            return RentACarContext.SaveChanges() > 0;
        }

        public bool DeletedById(int id)
        {
            var transaction = SelectById(id);
            return Delete(transaction);
        }

        public void Dispose()
        {
            RentACarContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public Transactions Insert(Transactions entity)
        {
            RentACarContext.Transactions.Add(entity);
            RentACarContext.SaveChanges();
            return entity;
        }

        public List<Transactions> Listele(Expression<Func<Transactions, bool>> predicate)
        {
            return RentACarContext.Transactions.Where(predicate).ToList();
        }

        public List<Transactions> SelectAll()
        {
            return RentACarContext.Transactions.AsNoTracking().ToList();
        }

        public Transactions SelectById(int id)
        {
            return RentACarContext.Transactions.Where(x => x.TransactionID == id).SingleOrDefault();
            //singleOrDefault varsa satır gönder yoksa null gönder
        }

        public int Update(Transactions entity)
        {
            //AddOrUpdate = db'de veri yoksa kaydeder var ise günceller
            RentACarContext.Transactions.AddOrUpdate(entity);
            return RentACarContext.SaveChanges(); //etkilenen satır sayısını döndürür
        }
    }
}
