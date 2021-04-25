using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> CreateAsync(int productId, RatingVM ratingVM){
            var client = _httpCleint.CreateClient("host");
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await client.PostAsJsonAsync("rating/"+productId+"/"+userId,ratingVM);           //somthing
            return Redirect("/product/"+productId);
        }
    }
}