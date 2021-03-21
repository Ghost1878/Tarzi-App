using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Data.Services
{
    public class OrderService : GenericRepo<Order, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db) : base(db) { _db = db; }

        public IQueryable<Order> GetAllOrders()
        {
            var orders = _db.Orders.Include(o => o.OrderDetails)
                                   .Include(c => c.Customer)
                                   .Include(t => t.Category);
            return orders;
        }

        public async Task<Order> GetOrderDetails(int id)
        {
            var order = await _db.Orders.Include(o => o.Category)
                                       .Include(od => od.OrderDetails)
                                       .Include(c => c.Customer)
                                       .FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }


    }
}