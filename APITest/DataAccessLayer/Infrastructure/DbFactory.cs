using DataAccessLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DBContext dbContext;

        public DBContext Init()
        {
            return dbContext ?? (dbContext = new DBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

    }
}
