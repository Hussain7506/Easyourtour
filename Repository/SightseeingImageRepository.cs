using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class SightseeingImageRepository : Repository<SightseeingImage>, ISightseeingImage
    {
        private ApplicationDbContext _db;
        public SightseeingImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(SightseeingImage obj)
        {
            _db.SightseeingImages.Update(obj);
        }
    }
}
