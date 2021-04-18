using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.ViewModel;
using AutoMapper;
using BackEnd.Interface;
using System.Threading.Tasks;
using Shared.Enum;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productSer;
        public ProductController(IProductService productService){
            _productSer = productService;
        }

        [HttpGet]
        public async Task<List<ProductVM>> GetListAsync(int categoryId, SortProduct? sort = null, int pageSize = 0, int page = 0){
            var re = await _productSer.GetListAsync(categoryId,sort,pageSize,page);
            HttpContext.Response.Headers.Add("total-item",re.totalItem.ToString());
            return re.products;
        }

        [HttpGet("search")]
        public async Task<List<ProductVM>> SearchAsync(string query, SortProduct? sort = null, int pageSize = 0, int page = 0){
             var re = await _productSer.SearchAsync(query,sort,pageSize,page);
            HttpContext.Response.Headers.Add("total-item",re.totalItem.ToString());
            return re.products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVM>> GetAsync(int id){
           if(id<=0) return BadRequest();
           var result = await _productSer.GetAsync(id);
           return result;
        }

        [HttpDelete("{id}")]     
        public async Task<ActionResult> DeleteAsync(int id)
        {    
            if(id<=0) return BadRequest();
             var result = await _productSer.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ProductVM productVM )
        {    
            if(id != productVM.proID) return BadRequest();
             var result = await _productSer.UpdateAsync(id, productVM);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProductVM>> CreateAsync(ProductVM productVM)
        {
            if(!ModelState.IsValid) return BadRequest();
             var result = await _productSer.CreateAsync(productVM);
            return result;
        }

    }
}