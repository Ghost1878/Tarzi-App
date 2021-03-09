using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Data.Services
{
    public class OrderDetailsService : GenericRepo<OrderDetails, ApplicationDbContext>
    {
        public OrderDetailsService(ApplicationDbContext db) : base(db)
        {
        }
    }
}