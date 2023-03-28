using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5_CodeFirst_FromScratch.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        public string VoterName { get; set; }
        [Range(0, 5), Required]
        public int NumStars { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
