using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;
//using BackEnd.Data;

namespace CustomerSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        //add CustomerSite Controller
        public async Task<IActionResult> Detail(int id)
        {
            var httpclient = new HttpClient();
            httpclient.BaseAddress = new Uri("https://localhost:44324/");
            var resp = await httpclient.GetAsync("product/" + id);
            var reuslt = await resp.Content.ReadFromJsonAsync<ProductVM>();
            ViewBag.Item=1;
            ViewData["Items"]=9.2;
            return View(reuslt);
        }
    }
}