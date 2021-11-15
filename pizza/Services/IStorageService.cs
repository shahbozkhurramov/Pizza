using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pizza.Entity;

namespace pizza.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, Exception exception)> InsertPizzaAsync(Entity.Pizza pizza);
        Task<(bool IsSuccess, Exception exception)> DeletePizzaAsync(Guid id);
        Task<(bool IsSuccess, Exception exception)> UpdatePizzaAsync(Guid id, Entity.Pizza pizza);
        Task<List<Entity.Pizza>> GetPizzaAsync(
            Guid id = default(Guid), 
            string title = default(string),
            string shortName = default(string),
            EPizzaStockStatus? status = null, 
            string ingredients = default(string),
            double price = default(double)
        );
    }
}