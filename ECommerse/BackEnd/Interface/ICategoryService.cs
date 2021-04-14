using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.ViewModel;

namespace BackEnd.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetListAsync();
        Task<CategoryVM> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, CategoryVM categoryvm);
        Task<CategoryVM> CreateAsync(CategoryVM categoryvm);
    }
}