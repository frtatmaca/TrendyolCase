using TrendyolCase.Enums;

namespace TrendyolCase.Models
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
            deliveryCost = CalculateDeliveryCostForCoupon(deliveryCost);

            return deliveryCost;
        }

        private decimal CalculateDeliveryCostForCoupon(decimal deliveryCost)
        {
            if (Coupon != null)
            {
                if (deliveryCost >= Coupon.MinimumPriceAmount)
                    deliveryCost = deliveryCost - Coupon.Discount;
            }

            return deliveryCost;
        }

        private decimal CalculateDeliveryCostForCampign(decimal deliveryCost)
        {
            deliveryCost = CalculateDeliveryCostForProductCampign(deliveryCost);
            deliveryCost = CalculateDeliveryCostForCategoryCampign(deliveryCost);

            return deliveryCost;
        }

        private decimal CalculateDeliveryCostForProductCampign(decimal deliveryCost)
        {
            if (Product.Campaign != null)
            {
                Campaign cmp = Product.Campaign;
                switch (Product.Campaign.DiscountScope)
                {
                    case DiscountScope.Both:
                        if (Quantity >= cmp.MinimumProdcutCount)
                            deliveryCost = deliveryCost - cmp.Discount;

                        break;
                    case DiscountScope.PriceAmount:
                        if (deliveryCost >= cmp.MinimumPriceAmount)
                            deliveryCost = deliveryCost - cmp.Discount;

                        break;
                    case DiscountScope.ProductCount:
                        if (Quantity >= cmp.MinimumProdcutCount)
                            deliveryCost = deliveryCost - cmp.Discount;

                        break;
                    default:
                        break;
                }
            }

            return deliveryCost;
        }

        private decimal CalculateDeliveryCostForCategoryCampign(decimal deliveryCost)
        {
            if (Product.Category.Campaign != null)
            {
                Campaign cmp = Product.Category.Campaign;
                if (Quantity >= cmp.MinimumProdcutCount)
                    deliveryCost = deliveryCost - cmp.Discount;
            }

            return deliveryCost;
        }

        public int CartId { get; set; }
        public Product Product { get; set; }
        public Coupon Coupon { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
