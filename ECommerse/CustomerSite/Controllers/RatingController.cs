using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace CustomerSite.Controllers
{
    public class RatingController : Controller
    {
        private readonly IHttpClientFactory _httpCleint;

        public RatingController(IHttpClientFactory httpCleint)
        {
            _httpCleint = httpCleint;
        }
        
        [HttpPost("/rating/{productId}")]
        public IActionResult Create(int productId, RatingVM ratingVM){
            var client = _httpCleint.CreateClient("host");
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            client.PostAsJsonAsync("rating/"+productId+"/"+userId,ratingVM);            //somthing
            return Redirect("ProductDetail");
        }
    }
}