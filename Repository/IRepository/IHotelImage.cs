using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface IHotelImage : IRepository<HotelImage>
    {
        void Update(HotelImage obj);
        void Save();
    }
}
