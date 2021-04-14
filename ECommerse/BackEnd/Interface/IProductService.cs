using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Enum;
using Shared.ViewModel;

namespace BackEnd.Interface
{
    public interface IProductService
    {
        Task<(List<ProductVM> products, int totalItem)> GetListAsync(int categoryId, SortProduct? sort, int pageSize, int page);
        Task<(List<ProductVM> products, int totalItem)> SearchAsync(string query, SortProduct? sort, int pageSize, int page);
        Task<ProductVM> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ProductVM productvm);
        Task<ProductVM> CreateAsync(ProductVM productvm);
    }
}