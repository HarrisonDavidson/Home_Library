using System.ComponentModel.DataAnnotations;

namespace HomeLibrary.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string YearReleased { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Image { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Format { get; set; }

        public string Notes { get; set; }

    }
}
