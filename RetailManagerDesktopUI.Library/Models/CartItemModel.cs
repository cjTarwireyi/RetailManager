namespace RetailManagerDesktopUI.Library.Models
{
    public class CartItemModel
    {
        public ProductModel Product { get; set; }
        public int QuantityInCart { get; set; }      

        public string DisplayText
        {
            get 
            {
                return $"{Product.ProductName.TrimEnd()}({QuantityInCart})"; 
            }
        }

    }
}
