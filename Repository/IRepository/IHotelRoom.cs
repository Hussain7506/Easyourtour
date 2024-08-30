using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface IHotelRoom : IRepository<HotelRoom>
    {
        void Update(HotelRoom obj);
        void Save();
    }
}
