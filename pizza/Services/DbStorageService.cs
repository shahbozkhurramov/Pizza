using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pizza.Data;
using pizza.Entity;

namespace pizza.Services
{
    public class DbStorageService : IStorageService
    {
        private readonly PizzaDbContext _context;
        private readonly ILogger<DbStorageService> _logger;

        public DbStorageService(PizzaDbContext context, ILogger<DbStorageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, Exception exception)> DeletePizzaAsync(Guid id)
        {
            try
            {
                var pizza = await _context.Pizzas
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
                if(id!=default(Guid))
                {
                    _context.Pizzas.Remove(pizza);
                    await _context.SaveChangesAsync();
                    return (true, null);
                }
                else
                {
                    return (false, new Exception("Task does not exist!"));
                }
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }

        public async Task<List<Pizza>> GetPizzaAsync(
            Guid id = default(Guid), 
            string title = default(string),
            string shortName = default(string),
            EPizzaStockStatus? status = null, 
            string ingredients = default(string),
            double price = default(double))
        {
            var pizzas = _context.Pizzas.AsNoTracking();
            if(id!=default(Guid))
            {
                pizzas=pizzas.Where(t=>t.Id==id);
            }
            return await pizzas.ToListAsync();
        }

        public async Task<(bool IsSuccess, Exception exception)> InsertPizzaAsync(Pizza pizza)
        {
            try
            {
                _context.Pizzas.Add(pizza);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Pizza inserted!");
                return (true, null);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Insertion failed! {e.Message}");
                return (false, e);
            }
        }

        public async Task<(bool IsSuccess, Exception exception)> UpdatePizzaAsync(Guid id, Pizza pizza)
        {
            try
            {
                var pizz = await _context.Pizzas
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
                if(pizz != default(Pizza))
                {
                    _context.Pizzas.Update(pizza);
                    await _context.SaveChangesAsync();
                    return (true, null);
                }
                else
                {
                    return (false, new Exception("Task does not exist!"));
                }
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }
    }
}