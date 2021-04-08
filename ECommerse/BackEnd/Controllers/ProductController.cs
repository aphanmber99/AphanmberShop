using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private AplicationDbContext _context;
        public ProductController(AplicationDbContext context){
            _context = context;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<List<Product>> GetListAsync(){
            List<Product> resutl = await _context.Products.ToListAsync();
            return resutl;
        }
        [HttpGet("search")]
        public async System.Threading.Tasks.Task<IActionResult> SearchAsync(string query){
            if(query == null || query == "") return BadRequest();
            List<Product> result = await _context.Products.Where(item => item.proName.Contains(query)).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]

        public async System.Threading.Tasks.Task<Product> GetAsync(int id){
            if(id<=0) return null;
            Product result = await _context.Products.FindAsync(id);
            return result;
        }
        [HttpDelete("{id}")]     
           public async System.Threading.Tasks.Task<IActionResult> DeleteAsync(int id)
        {    
            if(id<=0) return NotFound();
            Product obj =  await _context.Products.FindAsync(id);
            if(obj == null) return NotFound();
            _context.Remove(obj);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateAsync(int id, Product product )
        {    
            if(id<=0) return BadRequest();
            Product obj = await _context.Products.FindAsync(id);
            if(obj == null) return BadRequest();
            //
            obj.proName = product.proName;
            obj.proPrice = product.proPrice;
            obj.proDescription = product.proDescription;
            obj.Image = product.Image;
            //
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public IActionResult Create(Product product )
        {    
            _context.AddAsync(product);
            _context.SaveChangesAsync();
            return Ok();
        }

    }
}