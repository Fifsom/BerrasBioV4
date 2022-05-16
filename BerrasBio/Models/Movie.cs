using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
