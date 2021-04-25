using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Data;
using BackEnd.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [Authorize("Bearer")]
    public class UserController: ControllerBase
    {
        private IUserService _userSer;
        
        public UserController (IUserService userSer){
            _userSer = userSer;
        }
        
        [HttpGet]
        public async Task<List<UserVM>> GetList(){
            return await _userSer.GetList();
        }

    }
}