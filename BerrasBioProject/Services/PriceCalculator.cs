using BerrasBio.Models;
using BerrasBioProject.Data;

namespace BerrasBioProject.Services
{
    public static class PriceCalculator
    {
        public static List<Shows> Calculate(List<Shows> context)
        {
            foreach (var show in context)
            {
                show.Price = show.Movie.Price;
                // Sätter att filmer kostar 60kr extra efter 12:00
                if (show.ShowTime.Hour > 12)
                {
                    show.Price += 60;
                }
            }
            return context;
        }
    }
}
