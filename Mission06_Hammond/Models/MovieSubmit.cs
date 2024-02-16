using System.ComponentModel.DataAnnotations; //If things stop working, delete this line

namespace Mission06_Hammond.Models
{
    public class MovieSubmit
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; } 

        public string? Lent { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
