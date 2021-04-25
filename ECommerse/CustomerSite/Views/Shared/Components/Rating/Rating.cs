using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CustomerSite.Helper;
using Microsoft.AspNetCore.Mvc;
using Shared.Enum;
using Shared.ViewModel;

namespace CustomerSite.Views.Shared.Components.ProductPreview
{
    [ViewComponent]
    public class Rating : ViewComponent
    {

        private readonly IHttpClientFactory _httpFactory;

        public Rating(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {   
            var _httpCleint = _httpFactory.CreateClient("host");
            var resp = await _httpCleint.GetAsync("rating/product/"+productId);
            ViewBag.ProductId = productId;
            if (!resp.IsSuccessStatusCode) return View(new List<RatingVM>());
            var reuslt = await resp.Content.ReadFromJsonAsync<List<RatingVM>>();
            //
            return View(reuslt);
        }
    }
}