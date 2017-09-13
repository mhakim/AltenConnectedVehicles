using DataAccess.Shared.Interfaces;
using Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(Context context)
        {
            this.Context = context;
        }
        
        private Context Context { get; set; }
        
        public void Dispose()
        {
            this.Context.Dispose();
        }
        
        public void Save()
        {
            this.Context.SaveChanges();
        }        
    }
}
