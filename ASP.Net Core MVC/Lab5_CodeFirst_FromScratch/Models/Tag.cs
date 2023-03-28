namespace Lab5_CodeFirst_FromScratch.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
