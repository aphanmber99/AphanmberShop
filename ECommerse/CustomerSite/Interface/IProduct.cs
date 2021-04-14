using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Enum;
using Shared.ViewModel;

namespace CustomerSite.Interface
{
    public interface IProduct
    {
    Task<List<ProductVM>> GetListProduct();

    Task<ProductVM> GetProduct(int id);
  
    Task<ProductVM> Search(string query);
    }
}