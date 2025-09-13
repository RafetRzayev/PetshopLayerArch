using Microsoft.AspNetCore.Http;
using Petshop.BLL.Services.Contracts;

namespace Petshop.BLL.Services
{
    public class BasketManager
    {
        private const string BasketCookieName = "basket";

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductService _productService;

        public BasketManager(IHttpContextAccessor httpContextAccessor, IProductService productService)
        {
            _httpContextAccessor = httpContextAccessor;
            _productService = productService;
        }

        public void AddToBasket(int productId)
        {
            var basket = GetBasketFromCookie();
            var basketItem = basket.FirstOrDefault(item => item.ProductId == productId);
            if (basketItem != null)
            {
                basketItem.Quantity += 1;
            }
            else
            {
                basket.Add(new ViewModels.BasketCookieItemViewModel
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }
            SaveBasketToCookie(basket);
        }

        public void RemoveFromBasket(int productId)
        {
            var basket = GetBasketFromCookie();
            var basketItem = basket.FirstOrDefault(item => item.ProductId == productId);
            if (basketItem != null)
            {
                basket.Remove(basketItem);
                SaveBasketToCookie(basket);
            }
        }

        public async Task<ViewModels.BasketViewModel> GetBasketAsync()
        {
            var basket = GetBasketFromCookie();
            var basketViewModel = new ViewModels.BasketViewModel();
            foreach (var item in basket)
            {
                var product = await _productService.GetByIdAsync(item.ProductId);
                if (product != null)
                {
                    basketViewModel.Items.Add(new ViewModels.BasketItemViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name!,
                        ImageName = product.CoverImageName!,
                        Price = product.Price,
                        Quantity = item.Quantity
                    });
                }
            }
            return basketViewModel;
        }

        private List<ViewModels.BasketCookieItemViewModel> GetBasketFromCookie()
        {
            var cookie = _httpContextAccessor.HttpContext?.Request.Cookies[BasketCookieName];
            if (string.IsNullOrEmpty(cookie))
            {
                return new List<ViewModels.BasketCookieItemViewModel>();
            }
            return System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.BasketCookieItemViewModel>>(cookie) ?? [];
        }

        private void SaveBasketToCookie(List<ViewModels.BasketCookieItemViewModel> basket)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,
            };
            var cookieValue = System.Text.Json.JsonSerializer.Serialize(basket);
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(BasketCookieName, cookieValue, cookieOptions);
        }
    }
}
