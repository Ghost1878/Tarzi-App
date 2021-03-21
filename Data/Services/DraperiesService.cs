using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Data.Services
{
    public class DraperiesService : GenericRepo<DraperiesType, ApplicationDbContext>
    {
        public DraperiesService(ApplicationDbContext db) : base(db)
        {

        }
    }
}
