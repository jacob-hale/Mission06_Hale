using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Hale.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category {  get; set; }
        [Required]
        public string Title { get; set; }
        
        [Required]
        public int Year { get; set; }
        
        public string? Director { get; set; }
   
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }



    }
}
