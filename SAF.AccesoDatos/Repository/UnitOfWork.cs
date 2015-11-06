using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;
using SAF.Entidad;

namespace SAF.AccesoDatos.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

 
        private readonly IDatabaseFactory _databaseFactory;
        private TransactionScope _transaction;
        private readonly SI_SOCAUDEntities _db;


        public UnitOfWork()
        {
            _db = new SI_SOCAUDEntities();
            this._databaseFactory = new DatabaseFactory();

        }

        public void Dispose()
        {
        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _db; }
        }
 

        public SI_SOCAUDEntities DataContext()
        {
            return _databaseFactory.Get();
        }
    }
}
