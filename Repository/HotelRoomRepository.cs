using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class HotelRoomRepository : Repository<HotelRoom>, IHotelRoom
    {
        private readonly ApplicationDbContext _db;
        public HotelRoomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(HotelRoom obj)
        {
            var objFromDb = _db.HotelRooms.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.RoomType = obj.RoomType;
                objFromDb.priceonseason = obj.priceonseason;
                objFromDb.priceoffseason = obj.priceoffseason;
                objFromDb.capacity = obj.capacity;
                objFromDb.extrachargeperperson = obj.extrachargeperperson;
                objFromDb.HotelId = obj.HotelId;
                objFromDb.HotelRoomImages = obj.HotelRoomImages;
                objFromDb.Inclusions = obj.Inclusions;   

            }
        }
    }
}
