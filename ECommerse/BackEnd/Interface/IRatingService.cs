using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.ViewModel;

namespace BackEnd.Interface
{
    public interface IRatingService
    {
        Task<List<RatingVM>> GetListByUserAsync(string userId);
        Task<List<RatingVM>> GetListByProductsAsync(int productId);
        Task<RatingVM> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<RatingVM> CreateAsync(string userId, int productId, RatingVM ratingVM);
    }
}