using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Data;
using BackEnd.Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController: ControllerBase
    {
        private IRatingService _ratingSer;
        
        public RatingController (IRatingService ratingService){
            _ratingSer = ratingService;
        }
        
        [HttpGet]
        public async Task<List<RatingVM>> GetListByUserAsync(string userId){
            return await _ratingSer.GetListByUserAsync(userId);
        }

        [HttpGet]
        public async Task<List<RatingVM>> GetListByProductAsync(int productId){
            return await _ratingSer.GetListByProductsAsync(productId);
        }

        [HttpGet("{id}")]

        public async Task<RatingVM> GetAsync(int id){
            return await _ratingSer.GetAsync(id);
        }

        [HttpDelete("{id}")]     
        public async Task<IActionResult> DeleteAsync(int id)
        {    
            var result = await _ratingSer.DeleteAsync(id);
            if(result == false) return BadRequest();
            return Ok();
        }

        [HttpPost("{productId}/{userId}")]
        public async Task<IActionResult> CreateAsync(string userId, int productId, RatingVM ratingVM )
        {    
            if(userId == null || productId <= 0 ) return BadRequest();
            var result = await _ratingSer.CreateAsync(userId,productId, ratingVM);
            if(result == null) return Problem();
            return Ok();
        }
    }
}