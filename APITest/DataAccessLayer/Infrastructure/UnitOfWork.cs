using DataAccessLayer.Database;
using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IDbFactory dbFactory;
        private DBContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DBContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            //DbContext.Commit();
        }
    }
}
