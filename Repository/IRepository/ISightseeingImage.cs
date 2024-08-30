using Easyourtour.Models;

namespace Easyourtour.Repository.IRepository
{
    public interface ISightseeingImage : IRepository<SightseeingImage>
    {
        void Update(SightseeingImage obj);
        void Save();
    }
}
