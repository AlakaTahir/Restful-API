using System.Collections.Generic;

namespace BookingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
