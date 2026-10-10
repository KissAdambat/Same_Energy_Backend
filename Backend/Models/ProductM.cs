namespace Backend.Models
{
    public class ProductM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string size { get; set; }
        public int stock { get; set; }
        public string image { get; set; }
        public string category { get; set; }
    }
}
