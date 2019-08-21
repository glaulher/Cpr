using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Cpr.Domain.LivroCaixa;

namespace Cpr.Data.Repositories
{
    public class LivroCaixaRepository : Repository<LivroCaixa>
    {
        public LivroCaixaRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public override LivroCaixa GetById(int id)
        {
            var query = _context.Set<LivroCaixa>().Include(l => l.Categoria).Where(e => e.Id == id);
            if(query.Any())
                return query.First();
            return null;
        }

        public override IEnumerable<LivroCaixa> All()
        {
            //var query = _context.Set<LivroCaixa>().Include(l => l.Categoria);
            var query = _context.Set<LivroCaixa>();
            return query.Any() ? query.ToList() : new List<LivroCaixa>();
        }
    }
}