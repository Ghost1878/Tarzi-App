using System;

namespace Tarzi_Backend.Models
{

    public abstract class Shared
    {
        public string AddedByUser { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
    }
}