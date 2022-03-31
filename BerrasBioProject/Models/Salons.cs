namespace BerrasBio.Models
{
    public class Salons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }

        public virtual ICollection<Shows>? Show { get; set; }
    }
}
