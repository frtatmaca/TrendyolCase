namespace TrendyolCase.Business.Models
{
    public class Cart
    {
        public Cart(Product product, int quantity, Coupon coupon)
        {
            Product = product;
            Quantity = quantity;
            Coupon = coupon;
        }

        public decimal CalculateDeliveryCost()
        {
            decimal deliveryCost = Quantity * Product.Price;
            deliveryCost = CalculateDeliveryCostForCampign(deliveryCost);
            deliveryCost = this.Coupon.CalculateDeliveryCostForCoupon(deliveryCost);

            return deliveryCost;
        }
    
        private decimal CalculateDeliveryCostForCampign(decimal deliveryCost)
        {
            deliveryCost = this.Product.Campaign.CalculateDeliveryCostForProduct(deliveryCost, Quantity);
            deliveryCost = this.Product.Category.Campaign.CalculateDeliveryCostForProduct(deliveryCost, Quantity);

            return deliveryCost;
        }        

        public int CartId { get; set; }
        public Product Product { get; set; }
        public Coupon Coupon { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
