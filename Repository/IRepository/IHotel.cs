using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface IHotel : IRepository<Hotel>
    {
        void Update(Hotel obj);
        void Save();
    }
}
