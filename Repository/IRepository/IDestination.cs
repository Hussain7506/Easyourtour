using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface IDestination : IRepository<Destination>
    {
        void Update(Destination obj);
        void Save();
    }
}
