using Easyourtour.Models;
using System.Linq.Expressions;

namespace Easyourtour.Repository.IRepository
{
    public interface ITransport : IRepository<Transport>
    {
        void Update(Transport obj);
        void Save();
    }
}
