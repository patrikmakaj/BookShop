using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime YearOfPublish { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public int NumberOfPages { get; set; }
        public Category Category { get; set; }
    }
}
