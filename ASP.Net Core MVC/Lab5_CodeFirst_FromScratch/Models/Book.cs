using System.ComponentModel.DataAnnotations;

namespace Lab5_CodeFirst_FromScratch.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublishedOn { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual PriceOffer PriceOffer { get; set; }
    }
}
