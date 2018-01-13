﻿using CakeShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class CakeRepository : ICakeRepository
    {
        private readonly CakeShopDbContext _context;

        public CakeRepository(CakeShopDbContext context)
        {
            _context = context;
        }

        public async Task<Cake> GetCakeById(int cakeId)
        {
            return await _context.Cakes.FirstAsync(e => e.Id == cakeId);
        }


        public async Task<IEnumerable<Cake>> GetCakes(string category = null)
        {

            var query = _context.Cakes
                .Include(c => c.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(c => c.Category.Name == category);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Cake>> GetCakesOfTheWeek()
        {
            return await _context.Cakes
                .Where(e => e.IsCakeOfTheWeek)
                .Include(e => e.Category)
                .ToListAsync();
        }
    }
}
