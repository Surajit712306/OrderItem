using System.ComponentModel.DataAnnotations;

namespace OrderItem.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
    }
}
