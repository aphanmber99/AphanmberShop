using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Data;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Shared.ViewModel;

namespace BackEnd.Service
{
    public class CategoryService : ICategoryService
    {
        private AplicationDbContext _context;
        private IMapper _mapper;

        public CategoryService(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryVM> CreateAsync(CategoryVM categoryvm)
        {
            var cate = _mapper.Map<Category>(categoryvm);
            await _context.Categories.AddAsync(cate);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryVM>(cate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0) return false;
            Category obj = await _context.Categories.FindAsync(id);
            if (obj == null) return false;
            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public async Task<CategoryVM> GetAsync(int id)
        {
            if (id <= 0) return null;
            Category result = await _context.Categories.FindAsync(id);
            if (result == null) return null;
            return _mapper.Map<CategoryVM>(result);
        }

        public async Task<List<CategoryVM>> GetListAsync()
        {
            List<Category> result = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryVM>>(result);
        }

        public async Task<bool> UpdateAsync(int id, CategoryVM categoryvm)
        {
            if (id <= 0) return false;
            Category obj = await _context.Categories.FindAsync(id);
            if (obj == null) return false;
            obj.Name = categoryvm.Name;
            _context.SaveChanges();
            return true;
        }
    }
}