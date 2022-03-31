using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Shows
    {
        public int Id { get; set; }
        [Display(Name = "Time"), DataType(DataType.Time)]
        public DateTime ShowTime { get; set; }
        public int MovieId { get; set; }
        public int SalonId { get; set; }
        public decimal Price { get; set; } = 0;
        public int SeatsTaken { get; set; } = 0;


        public virtual Movies Movie { get; set; }
        public virtual Salons Salon { get; set; }
        public virtual ICollection<Bookings>? Booking { get; set; }
    }
}