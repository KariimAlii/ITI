using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5_CodeFirst_FromScratch.Models
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public int NewPrice { get; set; }
        public string PromotionalText { get; set; }
        [ForeignKey("Book")]
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }

    }
}
