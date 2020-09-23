namespace TrendyolCase.Models
{
    public class Product
    {
        public Product(string title, decimal price, Category category)
        {
            ProductId = 0; //auto-increment
            Category = category;
            Title = title;
            Price = price;
        }

        public Product(string title, decimal price, Category category, Campaign campaign)
        {
            ProductId = 0; //auto-increment
            Category = category;
            Campaign = campaign;
            Title = title;
            Price = price;
        }

        public int ProductId { get; set; }
        public Category Category { get; set; }
        public Campaign Campaign { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
