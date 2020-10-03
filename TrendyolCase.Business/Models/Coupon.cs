namespace TrendyolCase.Business.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public decimal Discount { get; set; }
        public decimal MinimumPriceAmount { get; set; }

        public decimal CalculateDeliveryCostForCoupon(decimal deliveryCost)
        {
            if (deliveryCost >= this.MinimumPriceAmount)
                deliveryCost = deliveryCost - this.Discount;

            return deliveryCost;
        }
    }
}
