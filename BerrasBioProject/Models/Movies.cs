using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<Shows>? Show { get; set; }
    }
}
