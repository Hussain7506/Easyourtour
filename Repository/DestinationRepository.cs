using Easyourtour.Data;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;

namespace Easyourtour.Repository
{
    public class DestinationRepository : Repository<Destination>, IDestination
    {
        private ApplicationDbContext _db;
        public DestinationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Destination obj)
        {
            _db.Destinations.Update(obj);
        }
    }
}
