namespace RetailManagerDataManager.Library.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Productname { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
