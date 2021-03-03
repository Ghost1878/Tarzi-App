using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;
using Tarzi_Backend.ViewModels;

namespace Tarzi_Backend.Data.Services
{
    public class OrderService : GenericRepo<CustomerOrderViewModel, ApplicationDbContext>
    {
        public OrderService(ApplicationDbContext db) : base(db)
        {

        }
    }
}