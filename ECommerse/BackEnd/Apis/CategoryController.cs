using System.Collections.Generic;
using BackEnd.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CategoryController: ControllerBase
    {
        private ICategoryService _cateService;
        
        public CategoryController (ICategoryService cateService){
            _cateService = cateService;
        }
        
        [HttpGet]
        public async Task<List<CategoryVM>> GetListAsync(){
            return await _cateService.GetListAsync();
        }
        [HttpGet("{id}")]

        public async Task<CategoryVM> GetAsync(int id){
            return await _cateService.GetAsync(id);
        }
        [HttpDelete("{id}")]     
           public async Task<IActionResult> DeleteAsync(int id)
        {    
            var result = await _cateService.DeleteAsync(id);
            if(result == false) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CategoryVM category )
        {    
            var result = await _cateService.UpdateAsync(id, category);
            if(result == false) return BadRequest();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryVM category )
        {    
            var result = await _cateService.CreateAsync(category);
            if(result == null) return BadRequest();
            return Ok();
        }

    }
}
