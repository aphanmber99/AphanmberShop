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
    public class RatingService : IRatingService
    {

        private AplicationDbContext _context;
        private IMapper _mapper;

        public RatingService(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RatingVM> CreateAsync(string userId, int productId, RatingVM ratingVM)
        {
            var rating = _mapper.Map<Rating>(ratingVM);
            rating.UserAcc = userId;
            rating.ProductID = productId;
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            return _mapper.Map<RatingVM>(rating);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0) return false;
            Rating obj = await _context.Ratings.FindAsync(id);
            if (obj == null) return false;
            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public async Task<RatingVM> GetAsync(int id)
        {
            if (id <= 0) return null;
            Rating result = await _context.Ratings.Where(item => item.ID == id)
                                    .Include(item => item.User)
                                    .FirstAsync();
            if(result == null) return null;
            return _mapper.Map<RatingVM>(result);
        }

        public async Task<List<RatingVM>> GetListByProductsAsync(int productId)
        {
            List<Rating> result = await _context.Ratings.Where(item => item.ProductID == productId)
                                                        .Include(item => item.User)
                                                        .ToListAsync();
            var feeVMs = _mapper.Map<List<RatingVM>>(result);
            return feeVMs;
        }

        public async Task<List<RatingVM>> GetListByUserAsync(string userId)
        {
            List<Rating> result = await _context.Ratings.Where(item => item.UserAcc == userId)
                                                         .Include(item => item.User)
                                                         .ToListAsync();
            var feeVMs = _mapper.Map<List<RatingVM>>(result);
            return feeVMs;
        }
    }
}