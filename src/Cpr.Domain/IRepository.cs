using System.Collections.Generic;

namespace Cpr.Domain
{
    public interface IRepository<TEntity>
    {
         TEntity GetById(int id);
         IEnumerable<TEntity> All();
         void Save(TEntity entity); 
         void Delete(TEntity entity); 
    }
}