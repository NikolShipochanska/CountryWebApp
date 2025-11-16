using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CountryWebApp.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the city is required!")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Please select a country!")]
        public int CountryId { get; set; }
    }
}
