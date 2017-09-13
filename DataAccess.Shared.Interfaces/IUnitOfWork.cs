using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shared.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();        
    }
}
