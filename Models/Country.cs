using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CountryWebApp.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the country is required!")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The capital is required!")]
        public string Capital { get; set; } = null!;
        public long Population { get; set; }

        public List<City> Cities { get; set; } = new List<City>();
    }
}
