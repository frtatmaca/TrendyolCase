using System.Collections.Generic;
using TrendyolCase.Business.Enums;

namespace TrendyolCase.Business.Models
{
    public class Campaign
    {
        public Campaign()
        {
            Category = new List<Category>();
            Product = new List<Product>();
        }

        public decimal CalculateDeliveryCostForProduct(decimal deliveryCost, int quantity)
        {
            switch (this.DiscountScope)
            {
                case TrendyolCase.Business.Enums.DiscountScope.Both:
                    if (quantity >= this.MinimumProdcutCount)
                        deliveryCost = deliveryCost - this.Discount;

                    break;
                case TrendyolCase.Business.Enums.DiscountScope.PriceAmount:
                    if (deliveryCost >= this.MinimumPriceAmount)
                        deliveryCost = deliveryCost - this.Discount;

                    break;
                case TrendyolCase.Business.Enums.DiscountScope.ProductCount:
                    if (quantity >= this.MinimumProdcutCount)
                        deliveryCost = deliveryCost - this.Discount;

                    break;
                default:
                    break;
            }

            return deliveryCost;
        }

        private decimal CalculateDeliveryCostForCategory(decimal deliveryCost, int quantity)
        {
            if (quantity >= this.MinimumProdcutCount)
                deliveryCost = deliveryCost - this.Discount;

            return deliveryCost;
        }

        public int CampaignId { get; set; }
        public DiscountScope? DiscountScope { get; set; }
        public decimal Discount { get; set; }
        public decimal? MinimumPriceAmount { get; set; }
        public int? MinimumProdcutCount { get; set; }
        public List<Category> Category { get; set; }
        public List<Product> Product { get; set; }
    }
}
