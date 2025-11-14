using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseFirstApproach.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
