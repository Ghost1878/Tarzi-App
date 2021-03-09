using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;
using Tarzi_Backend.ViewModels;

namespace Tarzi_Backend.Data.Services
{
    public class OrderService : GenericRepo<Order, ApplicationDbContext>
    {
        public readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }




    }
}