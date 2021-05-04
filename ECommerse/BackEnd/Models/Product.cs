using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Product
    {
        [Key]
        public int proID { get; set; }
        public string proName { get; set; }
        public string proDescription { get; set; }
        public double proPrice { get; set; }
        public string Image { get; set; }

        // nav
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}