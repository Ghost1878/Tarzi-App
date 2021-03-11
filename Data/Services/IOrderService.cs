using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;
using Tarzi_Backend.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Tarzi_Backend.Data.Services
{
    public interface IOrderService : IGenericRepo<Order>
    {
    Task<IEnumerable<Order>> GetOrders();
    }
}