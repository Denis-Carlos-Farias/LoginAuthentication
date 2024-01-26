namespace LoginAuthentication.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool Available { get; set; }
    }
}
