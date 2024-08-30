using Easyourtour.Data;
using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public class TransportRepository : Repository<Transport>, ITransport
    {
        private readonly ApplicationDbContext _db;
        public TransportRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Transport obj)
        {
            var objFromDb = _db.Transports.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.CarType = obj.CarType;
                objFromDb.CarCap = obj.CarCap;
                objFromDb.BaseDistance = obj.BaseDistance;
                objFromDb.BasePrice = obj.BasePrice;
                objFromDb.PricePerKm = obj.PricePerKm;
                objFromDb.LocationId = obj.LocationId;

            }
        }
    }
}
