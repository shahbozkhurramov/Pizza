using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pizza.Entity
{
    public class Pizza
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string ShortName { get; set; }
        [Required]
        public EPizzaStockStatus StockStatus { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Ingredients { get; set; }
        [Required]
        [Range(0, 1000)]
        public double Price { get; set; }
        [Obsolete("Only for entity binding")]
        public Pizza() { }
        public Pizza(string title, string shortName, EPizzaStockStatus stockStatus, string ingredients, double price)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.ShortName = shortName;
            this.StockStatus = stockStatus;
            this.Ingredients = ingredients;
            this.Price = price;
        }
    }
}