using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;
namespace Tarzi_Backend.Data.Services
{
    public class CustomerService : GenericRepo<Customer, ApplicationDbContext>
    {
        public CustomerService(ApplicationDbContext db) : base(db)
        {
        }


    }
}