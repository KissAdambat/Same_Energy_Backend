namespace Backend.Models
{
    public class OrderM
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string status { get; set; }
        public decimal total_price { get; set; }
        public DateTime order_date { get; set; }
    }
}
