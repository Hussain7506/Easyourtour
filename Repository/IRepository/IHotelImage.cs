using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface IHotelImage : IRepository<HotelImage>
    {
        void Update(LocationImage obj);
        void Save();
    }
}
