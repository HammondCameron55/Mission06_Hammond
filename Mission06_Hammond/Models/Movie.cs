using System.ComponentModel.DataAnnotations; //If things stop working, delete this line

namespace Mission06_Hammond.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage="Sorry you must enter a First Name")]
        public string Title { get; set; }

        
        public string? CategoryId { get; set; }

        [Required(ErrorMessage = "Sorry you must enter the year the movie came out")]
        public int Year { get; set; }

        
        public string? Director { get; set; }

        
        public string? Rating { get; set; }

        [Required(ErrorMessage ="Sorry, you must mark whether or not the version you watched was edited")]
        public bool Edited { get; set; } 

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Sorry, you must mark whether or not the movie has been copied to Plex")]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
