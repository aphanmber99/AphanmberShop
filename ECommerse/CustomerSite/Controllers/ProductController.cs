using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CustomerSite.Helper;
using Microsoft.AspNetCore.Mvc;
using Shared.Enum;
using Shared.ViewModel;

namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpCleint;
        
        private readonly int _pageSize = 8;

        public ProductController(IHttpClientFactory httpCleint)
        {
            _httpCleint = httpCleint;
        }

        [HttpGet("/product")]
        public async Task<IActionResult> ListProductAsync(int cate, SortProduct? sort = null, int page = 1){

            var client = _httpCleint.CreateClient("host");
            var queryString = RequestHelper.GetQueryString(cate, _pageSize, page, sort);
            var resp =  await client.GetAsync("product"+queryString);
            if(!resp.IsSuccessStatusCode) return Redirect("/Home/Error");
            var products = await resp.Content.ReadFromJsonAsync<List<ProductVM>>();
            
            var totalItem= 0;
            if (resp.Headers.Contains("total-item")) totalItem = Int32.Parse(resp.Headers.GetValues("total-item").First());
            //
            ViewBag.Total = totalItem;
            ViewBag.TotalPage = Math.Ceiling(totalItem / (_pageSize + 0.0));
            ViewBag.Cate = cate;
            ViewBag.Sort = sort;
            ViewBag.Page = page;

            return View( "ListProduct",products);
        }   

        [HttpGet("/product/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpCleint.CreateClient("host");
            var resp = await client.GetAsync("product/" + id);
            if(!resp.IsSuccessStatusCode) return Redirect("/Home/Error");
            var reuslt = await resp.Content.ReadFromJsonAsync<ProductVM>();
            return View("ProductDetail",reuslt);
        }
    }
}