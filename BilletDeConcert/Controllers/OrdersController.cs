using BilletDeConcert.Data.Cart;
using BilletDeConcert.Data.Services;
using BilletDeConcert.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BilletDeConcert.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IConcertsService _concertsService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IConcertsService concertsService, ShoppingCart shoppingCart)
        {
            _concertsService = concertsService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _concertsService.GetConcertByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _concertsService.GetConcertByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


    }
}
