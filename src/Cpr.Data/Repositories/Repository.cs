using Cpr.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Cpr.Data.Repositories
{
    //classe genérica
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext _context;

        public Repository (ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual TEntity GetById(int id)
        {
        //retorna de forma genéria
         var query = _context.Set<TEntity>().Where(e => e.Id == id);
            if(query.Any())
                return query.First();
            return null;
        }

        public virtual IEnumerable<TEntity> All()
        {
            var query = _context.Set<TEntity>();

            if(query.Any())
                return query.ToList();

            return new List<TEntity>();
        }

        public virtual void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);   
        }

         public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);   
        }
    }
}