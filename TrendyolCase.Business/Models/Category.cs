namespace TrendyolCase.Business.Models
{
    public class Category
    {
        public Category(string title)
        {
            CategoryId = 0; //auto-incremenet
            Title = title;
        }

        public Category(string title, Campaign campaign)
        {
            CategoryId = 0; //auto-incremenet
            Title = title;
            Campaign = campaign;
        }

        public decimal CalculateDeliveryCost(decimal deliveryCost, int quantity)
        {
            return Campaign.CalculateDeliveryCostForProduct(deliveryCost, quantity);
        }

        public int CategoryId { get; set; }
        public Campaign Campaign { get; set; }
        public string Title { get; set; }
    }
}
