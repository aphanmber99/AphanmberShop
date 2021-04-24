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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var _httpCleint = _httpFactory.CreateClient("host");

            var resp = await _httpCleint.GetAsync("rating/" + 0);
            ViewBag.ProductId = 0;
            if (!resp.IsSuccessStatusCode) return View(new List<RatingVM>());
            var reuslt = await resp.Content.ReadFromJsonAsync<List<RatingVM>>();
            //s
            return View(reuslt);
        }
    }
}