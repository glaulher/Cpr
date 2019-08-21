using System.Threading.Tasks;

namespace Cpr.Domain
{
    public interface IUnitOfWork
    {
         Task commit();
    }
}