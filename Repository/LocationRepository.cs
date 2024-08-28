using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class LocationRepository : Repository<Location>, ILocation
    {
        private readonly ApplicationDbContext _db;
        public LocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Location obj)
        {
            var objFromDb = _db.Locations.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.DestinationId = obj.DestinationId;
                objFromDb.LocationImages = obj.LocationImages;

            }
        }
    }
}
