using System.ComponentModel.DataAnnotations;

namespace Book_Order.Models
{
    public class orders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int bookId { get; set; }
        public int userid { get; set; }
        public int quantity { get; set; }
        public DateTime orderdate { get; set; }

    }
}
