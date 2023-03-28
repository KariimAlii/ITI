namespace Lab5_CodeFirst_FromScratch.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public virtual ICollection<BookAuthor> AuthorBooks { get; set; } = new HashSet<BookAuthor>();
    }
}
