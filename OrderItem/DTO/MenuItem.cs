namespace OrderItem.DTO
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool FreeDelivery { get; set; }
        public double Price { get; set; }
        public DateTime DateOfLaunch { get; set; }
        public bool Active { get; set; }
    }
}
