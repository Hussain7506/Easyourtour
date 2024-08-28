using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class HotelImageRepository : Repository<HotelImage>, IHotelImage
    {
        private ApplicationDbContext _db;
        public HotelImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(HotelImage obj)
        {
            _db.HotelImages.Update(obj);
        }
    }
}
