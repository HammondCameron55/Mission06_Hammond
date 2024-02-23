using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //If things stop working, delete this line

namespace Mission06_Hammond.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage="Sorry you must enter a First Name")]
        public string Title { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        //Navigation Property
        public Category? Category { get; set; } //This is a reference to the Category class Also it is a nullable type

        [Required(ErrorMessage = "Sorry you must enter the year the movie came out")]
        [Range(1888, 3000, ErrorMessage = "Sorry, the year must be between 1888 and Now")]
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
