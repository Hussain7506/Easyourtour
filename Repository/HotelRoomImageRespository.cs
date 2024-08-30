using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class HotelRoomImageRespository:Repository<HotelRoomImage>, IHotelRoomImage
    {
        private ApplicationDbContext _db;
        public HotelRoomImageRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(HotelRoomImage obj)
        {
            _db.HotelRoomImages.Update(obj);
        }
    }
}
