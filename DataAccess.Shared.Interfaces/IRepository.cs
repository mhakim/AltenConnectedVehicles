using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shared.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        bool IsExist(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Guid id);
    }
}
