using Microsoft.AspNetCore.Mvc;
using Petshop.BLL.Services;

namespace Petshop.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly BasketManager _basketManager;

        public BasketController(BasketManager basketManager)
        {
            _basketManager = basketManager;
        }

        public IActionResult AddToBasket(int productId)
        {
            _basketManager.AddToBasket(productId);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetBasket()
        {
            var model = await _basketManager.GetBasketAsync();

            return Json(model);
        }
    }
}
