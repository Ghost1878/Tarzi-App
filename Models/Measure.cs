namespace Tarzi_Backend.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public int Longness { get; set; }
        public int Shoulder { get; set; }
        public int SleeveLength { get; set; }
        public int Sleevewasae { get; set; }
        public int Neck { get; set; }
        public int Side { get; set; }
        public Order Order { get; set; }
    }
}