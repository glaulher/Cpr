using System.Threading.Tasks;
using Cpr.Domain;

namespace Cpr.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork (ApplicationDbContext context)
       {
           _context = context;
       }
       public async Task commit()
       {
           await _context.SaveChangesAsync();
       }
    }
}