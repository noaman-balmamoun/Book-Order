using System.ComponentModel.DataAnnotations;

namespace Book_Order.Models
{
    public class useraccounts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string pass { get; set; }
        public string role { get; set; }
        public string email { get; set; }

    }
}
