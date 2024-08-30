using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class SightseeingRepository : Repository<Sightseeing>, ISightseeing
    {
        private readonly ApplicationDbContext _db;
        public SightseeingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Sightseeing obj)
        {
            var objFromDb = _db.Sightseeings.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.LocationId = obj.LocationId;
                objFromDb.SightseeingImages = obj.SightseeingImages;
                objFromDb.EntryFee = obj.EntryFee;
            }
        }
    }
}
