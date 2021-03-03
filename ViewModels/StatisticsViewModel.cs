using System.Collections.Generic;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.ViewModels
{
    public class StatisticsViewModel
    {
        // private CustomerService _repo;

        // public StatisticsViewModel(CustomerService repo)
        // {
        //     _repo = repo;
        // }


        public int CustomersCount { get; set; }

    }
}