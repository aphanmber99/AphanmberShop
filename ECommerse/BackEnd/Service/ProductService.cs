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
    public class ProductService : IProductService

    {
        private AplicationDbContext _context;
        private IMapper _mapper;

        public ProductService(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVM> CreateAsync(ProductVM productvm)
        {
            var pro = _mapper.Map<Product>(productvm);
            await _context.Products.AddAsync(pro);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVM>(pro);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0) return false;
            Product obj = await _context.Products.FindAsync(id);
            if (obj == null) return false;
            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public async Task<ProductVM> GetAsync(int id)
        {
            if (id <= 0) return null;
            Product result = await _context.Products.FindAsync(id);
            if (result == null) return null;
            return _mapper.Map<ProductVM>(result);
        }

        public async Task<(List<ProductVM> products, int totalItem)> GetListAsync(int categoryId, SortProduct? sort, int pageSize, int page, string query = null)
        {
            var queryProduct = _context.Products.AsQueryable();
            if (categoryId != 0) queryProduct = queryProduct.Where(item => item.CategoryId == categoryId);
            if (query != null) queryProduct = queryProduct.Where(item => item.proName.Contains(query));

            var totalItem = queryProduct.Count();

            if (sort != null)
            {
                switch (sort)
                {
                    case SortProduct.highPrice:
                        queryProduct = queryProduct.OrderByDescending(item => item.proPrice);
                        break;
                    case SortProduct.lowPrice:
                        queryProduct = queryProduct.OrderBy(item => item.proPrice);
                        break;
                }
            }
            if (page != 0)
            {
                if (pageSize * (page - 1) <= totalItem) // 10
                    queryProduct = queryProduct.Skip(pageSize * (page - 1));
            }
            if (pageSize != 0)
                queryProduct = queryProduct.Take(pageSize);

            var result = await queryProduct.ToListAsync();

            var proVMs = _mapper.Map<List<ProductVM>>(result);

            return (proVMs, totalItem);
        }

        public async Task<bool> UpdateAsync(int id, ProductVM productvm)
        {
            if (id <= 0) return false;
            Product obj = await _context.Products.FindAsync(id);
            if (obj == null) return false;
            if (productvm.proName != null) obj.proName = productvm.proName;
            if (productvm.proDescription != null) obj.proDescription = productvm.proDescription;
            if (productvm.proPrice > 0) obj.proPrice = productvm.proPrice;
            if (productvm.CategoryId > 0) obj.CategoryId = productvm.CategoryId;
            if (productvm.Image != null) obj.Image = productvm.Image;
            _context.SaveChanges();
            return true;
        }
    }
}