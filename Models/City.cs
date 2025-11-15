using System.ComponentModel.DataAnnotations;

namespace CountryWebApp.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int CountryId { get; set; }

        public City() { }
    }
}
