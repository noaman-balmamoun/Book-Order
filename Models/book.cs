using System.ComponentModel.DataAnnotations;

namespace Book_Order.Models
{
    public class book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        public string info { get; set; }
        public int bookquantity { get; set; }
        public int price { get; set; }
        public int cataid { get; set; }
        public string author { get; set; }
        public string imgfile { get; set; }
    

    }
}
