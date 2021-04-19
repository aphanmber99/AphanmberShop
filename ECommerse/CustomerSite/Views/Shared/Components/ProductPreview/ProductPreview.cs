using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CustomerSite.Helper;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace CustomerSite.Views.Shared.Components.ProductPreview
{
    [ViewComponent]
    public class ProductPreview : ViewComponent
    {
        
        private readonly IHttpClientFactory _httpFactory;
        
        public ProductPreview(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync( int categoryId, string titlePreview)
        {
            var queryString = RequestHelper.GetQueryString(categoryId,4);
            var _httpCleint = _httpFactory.CreateClient("host");

            var resp = await  _httpCleint.GetAsync("product"+queryString);
            if(!resp.IsSuccessStatusCode) throw new Exception();
            var reuslt = await resp.Content.ReadFromJsonAsync<List<ProductVM>>();
            //s
            ViewBag.TitlePreview = titlePreview;
            return View(reuslt);
        }
    }
}