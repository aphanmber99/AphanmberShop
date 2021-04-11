using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Data;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Enum;
using Shared.ViewModel;

namespace BackEnd.Service
{
    public class ProductService : IProduct

    {
        private AplicationDbContext _context;
        private IMapper _mapper;
        public async Task<ProductVM> CreateAsync(ProductVM productvm)
        {
            var pro = _mapper.Map<Product>(productvm);
            await _context.Products.AddAsync(pro);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVM>(pro);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if(id<=0) return false;
            Product obj = await _context.Products.FindAsync(id);
            if(obj== null) return false;
            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public async Task<ProductVM> GetAsync(int id)
        {
            if(id <=0) return null;
            Product result = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductVM>(result);
        }

        public async Task<(List<ProductVM> products , int totalItem)> GetListAsync(int categoryId, SortProduct? sort = null,int pageSize = 0, int page = 0)
        {
            var queryProduct = _context.Products.AsQueryable();
            if(categoryId!=0) queryProduct = queryProduct.Where(item => item.CategoryId ==categoryId);
            var totalItem = queryProduct.Count();

            if(sort!=null){
                switch(sort){
                    case SortProduct.highPrice:
                        queryProduct = queryProduct.OrderByDescending(item => item.proPrice);
                        break;
                    case SortProduct.lowPrice:
                        queryProduct = queryProduct.OrderBy(item => item.proPrice);
                        break;
                }
            }
            if(page !=0){
                if(pageSize * (page-1) <= totalItem) // 10
                    queryProduct = queryProduct.Skip(page-1).Take(pageSize);
            }

            var result = await queryProduct.ToListAsync();


            var  proVMs =  new List<ProductVM>();
            foreach (var item in result)
            {
                var proVM = _mapper.Map<ProductVM>(item);
                proVMs.Add(proVM);
            }
            return (proVMs, totalItem);
        }
        public async Task<(List<ProductVM> products, int totalItem)> SearchAsync(string query, SortProduct? sort, int pageSize, int page)
        {
            var queryProduct = _context.Products.AsQueryable();
            if(query!="") queryProduct = queryProduct.Where(item => item.proName.Contains(query));
            var totalItem = queryProduct.Count();

            if(sort!=null){
                switch(sort){
                    case SortProduct.highPrice:
                        queryProduct = queryProduct.OrderByDescending(item => item.proPrice);
                        break;
                    case SortProduct.lowPrice:
                        queryProduct = queryProduct.OrderBy(item => item.proPrice);
                        break;
                }
            }
            if(page !=0){
                if(pageSize * (page-1) <= totalItem) // 10
                    queryProduct = queryProduct.Skip(page-1).Take(pageSize);
            }

            var result = await queryProduct.ToListAsync();


            var  proVMs =  new List<ProductVM>();
            foreach (var item in result)
            {
                var proVM = _mapper.Map<ProductVM>(item);
                proVMs.Add(proVM);
            }
            return (proVMs, totalItem);
        }

        public Task<bool> UpdateAsync(int id, ProductVM productvm)
        {
            throw new System.NotImplementedException();
        }
    }
}