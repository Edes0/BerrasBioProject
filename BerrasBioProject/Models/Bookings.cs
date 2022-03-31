using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Bookings
    {

        public int Id { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Display(Name = "Movie & Time: ")]
        public int ShowId { get; set; }

        [Display(Name = "Amount of tickets")]
        [Range(1, 12)]
        public int NumOfSeats { get; set; }

        public virtual Shows Show { get; set; }

        //public decimal TotalCalculator()
        //{
        //    decimal number;

        //    number = NumOfSeats * 

        //    return number;
        //}
    }
}
