using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class LocationImageRepository : Repository<LocationImage >, ILocationImage
    {
        private ApplicationDbContext _db;
        public LocationImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(LocationImage obj)
        {
            _db.LocationImages.Update(obj);
        }
    }
}
