using System.ComponentModel.DataAnnotations;
namespace Site.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? Adress { get; set; }
        public string? Landlord { get; set; }
        public decimal Price { get; set; }
        public decimal Duration { get; set; }

        public int LordId { get; set; }

        public int Rented { get; set; }
    }
}
