using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface ILocationImage : IRepository<LocationImage>
    {
        void Update(LocationImage obj);
        void Save();
    }
}
