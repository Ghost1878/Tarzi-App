using System;

namespace Tarzi_Backend.Models
{
    public abstract class Shared
    {
        public DateTimeOffset? CreatedAt { get; set; } = DateTime.Now;
    //    public DateTimeOffset? ModifiedAt { get; set; } = DateTime.Now;
    }
}