using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotel
    {
        private readonly ApplicationDbContext _db;
        public HotelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Hotel obj)
        {
            var objFromDb = _db.Hotels.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.LocationId = obj.LocationId;
                objFromDb.HotelImages = obj.HotelImages;
                objFromDb.Amenities = obj.Amenities;
                objFromDb.Rating = obj.Rating;

            }
        }
    }
}
