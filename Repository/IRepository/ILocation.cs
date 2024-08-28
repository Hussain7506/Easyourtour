using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface ILocation : IRepository<Location>
    {
        void Update(Location obj);
        void Save();
    }
}
