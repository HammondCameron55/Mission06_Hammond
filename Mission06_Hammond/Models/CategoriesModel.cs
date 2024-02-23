using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Hammond.Models
{
    public class CategoriesModel
    {

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
