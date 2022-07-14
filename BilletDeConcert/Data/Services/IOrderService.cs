using BilletDeConcert.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BilletDeConcert.Data.Services
{
    public interface IOrderService
    {
        public interface IOrdersService
        {
            Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
            Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        } 
    }
}
