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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [Authorize("Bearer")]
    public class ProductController : ControllerBase
    {
        private IProductService _productSer;
        public ProductController(IProductService productService)
        {
            _productSer = productService;
        }

        [HttpGet]
        // [AllowAnonymous]
        public async Task<List<ProductVM>> GetListAsync(int categoryId, SortProduct? sort = null, int pageSize = 0, int page = 0)
        {
            var re = await _productSer.GetListAsync(categoryId, sort, pageSize, page);
            HttpContext.Response.Headers.Add("total-item", re.totalItem.ToString());
            return re.products;
        }

        [HttpGet("search")]
        // [AllowAnonymous]
        public async Task<List<ProductVM>> SearchAsync(string query, SortProduct? sort = null, int pageSize = 0, int page = 0)
        {
            var re = await _productSer.SearchAsync(query, sort, pageSize, page);
            HttpContext.Response.Headers.Add("total-item", re.totalItem.ToString());
            return re.products;
        }

        [HttpGet("{id}")]
        // [AllowAnonymous]
        public async Task<ActionResult<ProductVM>> GetAsync(int id)
        {
            if (id <= 0) return BadRequest();
            var result = await _productSer.GetAsync(id);
            return result;
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return BadRequest();
            var result = await _productSer.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        // [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateAsync([FromServices] IWebHostEnvironment env, int id, [FromForm] ProductVM productVM, IFormFile image)
        {
            if (id != productVM.proID) return BadRequest();
            productVM.Image=null;
            if (image != null)
            {
                var filePath = Path.Combine(env.WebRootPath, "images", image.FileName);
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    productVM.Image = image.FileName;
                }
                catch (Exception)
                {
                    throw new Exception("Can't upload image");
                }
            }
            var result = await _productSer.UpdateAsync(id, productVM);
            return Ok();
        }

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVM>> CreateAsync([FromServices] IWebHostEnvironment env, [FromForm] ProductVM productVM, IFormFile image)
        {
            if (!ModelState.IsValid) return BadRequest();
            productVM.Image=null;
            if (image != null)
            {
                var filePath = Path.Combine(env.WebRootPath, "images", image.FileName);
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    productVM.Image = image.FileName;
                }
                catch (Exception)
                {
                    throw new Exception("Can't upload image");
                }
            }
            var result = await _productSer.CreateAsync(productVM);
            return result;
        }

    }
}