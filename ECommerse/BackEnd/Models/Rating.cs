using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Rating
    {

        public int ID { get; set; }
        public int Rate { get; set; }
        public string Feedback { get; set; }

        [ForeignKey("User")]
        public string UserAcc { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public User User { get; set; }
    }
}