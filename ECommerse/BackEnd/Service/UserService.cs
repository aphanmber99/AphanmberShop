using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Data;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Shared.ViewModel;

namespace BackEnd.Service
{
    public class UserService : IUserService
    {

        private AplicationDbContext _context;
        private IMapper _mapper;

        public UserService (AplicationDbContext context, IMapper mapper){
            _context =context;
            _mapper =mapper;
        }

        public async Task<List<UserVM>> GetList()
        {
            List<User> result =  await _context.Users.ToListAsync();
            var  userVMs =  new List<UserVM>();
            foreach (var item in result)
            {
                var user = _mapper.Map<UserVM>(item);
                userVMs.Add(user);
            }
            return userVMs;
        }
    }
}