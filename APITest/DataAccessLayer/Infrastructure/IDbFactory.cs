using DataAccessLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DBContext Init();
    }
}
