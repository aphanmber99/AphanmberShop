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
    public class ProductSlider : ViewComponent
    {
        
        private readonly IHttpClientFactory _httpFactory;
        
        public ProductSlider(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync( int categoryId, string titleSlider)
        {
            var queryString = RequestHelper.GetQueryString(categoryId,6, 0 ,SortProduct.highPrice);
            var _httpCleint = _httpFactory.CreateClient("host");

            var resp = await  _httpCleint.GetAsync("product"+queryString);
            if(!resp.IsSuccessStatusCode) throw new Exception();
            var reuslt = await resp.Content.ReadFromJsonAsync<List<ProductVM>>();
            //s
            ViewBag.TitleSlider = titleSlider;
            return View(reuslt);
        }
    }
}