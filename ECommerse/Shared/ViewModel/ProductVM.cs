namespace Shared.ViewModel
{
    public class ProductVM
    {
        public int proID { get; set; }
        public string proName { get; set; }
        public string proDescription { get; set; }
        public double proPrice{get; set;}
        public string Image { get; set; }        
        // nav
        public int CategoryId {get;set;}
    }
}