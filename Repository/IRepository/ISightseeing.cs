using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface ISightseeing : IRepository<Sightseeing>
    {
        void Update(Sightseeing obj);
        void Save();
    }
}
