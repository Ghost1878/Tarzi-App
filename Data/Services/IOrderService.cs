using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;
using Tarzi_Backend.ViewModels;

namespace Tarzi_Backend.Data.Services
{
    public interface IOrderService : IGenericRepo<CustomerOrderViewModel>
    {

    }
}