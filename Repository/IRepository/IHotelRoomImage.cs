using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface IHotelRoomImage : IRepository<HotelRoomImage>
    {
        void Update(HotelRoomImage obj);
        void Save();
    }
}
