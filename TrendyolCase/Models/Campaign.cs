using System.Collections.Generic;
using TrendyolCase.Enums;

namespace TrendyolCase.Models
{
    public class Campaign
    {
        public Campaign()
        {
            Category = new List<Category>();
            Product = new List<Category>();
        }

        public int CampaignId { get; set; }
        public DiscountScope? DiscountScope { get; set; }
        public decimal Discount { get; set; }
        public decimal? MinimumPriceAmount { get; set; }
        public int? MinimumProdcutCount { get; set; }
        public List<Category> Category { get; set; }
        public List<Category> Product { get; set; }
    }
}
