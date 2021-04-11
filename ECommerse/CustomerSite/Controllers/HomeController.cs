using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerSite.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Shared.ViewModel;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHttpClientFactory _httpCleint;
        
        public HomeController(IHttpClientFactory httpCleint)
        {
            _httpCleint = httpCleint;
        }

        // public HomeController()
        // {}

        // public async Task<IActionResult> IndexAsync()
        // {
        //     var httpclient = new HttpClient();
        //     httpclient.BaseAddress = new Uri("https://localhost:5001/");
        //     var resp =await httpclient.GetAsync("product");
        //     var reuslt = resp.Content.ReadAsStringAsync();
        //     return View();
        // }

        public async Task<IActionResult> IndexAsync()
        {
            // var httpclient = _httpCleint.CreateClient("host");
            var httpclient = new HttpClient();
            httpclient.BaseAddress = new Uri("https://localhost:5001/");
            var resp =await httpclient.GetAsync("product");
            var reuslt =await resp.Content.ReadFromJsonAsync<List<ProductVM>>();
            ViewBag.ProductNews = reuslt.Take(3);
            return View();
        }


        //should it be another async method for category or we just override the IndexAsync()
        // another method for the cateGory 
    }
}
