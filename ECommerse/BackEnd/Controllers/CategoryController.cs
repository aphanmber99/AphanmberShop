using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CategoryController: ControllerBase
    {
        private AplicationDbContext _context;
        
        public CategoryController (AplicationDbContext context){
            context =_context;
        }
        [HttpGet]
        public async System.Threading.Tasks.Task<List<Category>> GetListAsync(){
            List<Category> result =  await _context.Categories.ToListAsync();
            return result;
        }
        [HttpGet("search")]
        public async System.Threading.Tasks.Task<IActionResult> SearchAsync(string query){
            if(query == null || query =="") return BadRequest();
            List<Category> result = await _context.Categories.Where(item => item.Name.Contains(query)).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]

        public async System.Threading.Tasks.Task<Category> GetAsync(int id){
            if(id<=0) return null;
            Category result = await _context.Categories.FindAsync(id);
            return result;
        }
        [HttpDelete("{id}")]     
           public async System.Threading.Tasks.Task<IActionResult> DeleteAsync(int id)
        {    
            if(id<=0) return NotFound();
            Category obj = await _context.Categories.FindAsync(id);
            if(obj == null) return NotFound();
            _context.Remove(obj);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateAsync(int id, Category category )
        {    
            if(id<=0) return BadRequest();
            Category obj = await _context.Categories.FindAsync(id);
            if(obj == null) return BadRequest();
            
            obj.Name = category.Name;
            obj.ID = category.ID;
           
        
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateAsync(Category category )
        {    
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
