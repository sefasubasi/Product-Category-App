namespace ProductCategoryApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public List<string> Tags { get; set; }
        public string Brand { get; set; }
        public string Sku { get; set; }
        public string WarrantyInformation { get; set; }
        public string ShippingInformation { get; set; }
        public string AvailabilityStatus { get; set; }
        public string ReturnPolicy { get; set; }
        public int MinimumOrderQuantity { get; set; }
        public List<string> Images { get; set; }
        public List<Review> Reviews { get; set; }
        public string Thumbnail { get; set; }

    }

    public class Review
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerEmail { get; set; }
    }
}

