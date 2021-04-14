using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerSite.Interface;
using Shared.Enum;
using Shared.ViewModel;

namespace CustomerSite.Service
{
    public class ProductService : IProduct

    {
        private readonly IHttpClientFactory _httpclient;
        public ProductService(IHttpClientFactory httpclient)
        { 
            _httpclient = httpclient;
        }

        public Task<List<ProductVM>> GetListProduct()
        {
            
            throw new System.NotImplementedException();
        }

        public Task<ProductVM> GetProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductVM> Search(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}