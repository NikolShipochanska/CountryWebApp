using System.ComponentModel.DataAnnotations;

namespace CountryWebApp.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Capital { get; set; }
        public long Population { get; set; }

        public List<City> Cities { get; set; }
        public Country() { }

    }
}
