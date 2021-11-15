using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pizza.Model
{
    public class UpdatedPizza
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string ShortName { get; set; }
        [Required]
        public EPizzaStockStatus? StockStatus { get; set; }
        [Required]
        [MaxLength(1024)]
        public List<string> Ingredients { get; set; }
        [Required]
        [Range(0, 1000)]
        public double Price { get; set; }
    }
}