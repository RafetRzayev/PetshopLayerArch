using Microsoft.AspNetCore.Mvc;
using Petshop.BLL.Services;
using System.Threading.Tasks;

namespace Petshop.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly BasketManager _basketManager;

        public CartController(BasketManager basketManager)
        {
            _basketManager = basketManager;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await _basketManager.GetBasketAsync();

            return View(basket);
        }

        [HttpPost]
        public IActionResult ChangeQuantity(int productId, int change)
        {
            _basketManager.ChangeQuantity(productId, change);
            return NoContent();
        }
    }
}
