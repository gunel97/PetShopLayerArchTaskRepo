﻿using Microsoft.AspNetCore.Http;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.Services
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

        public void AddToBasket (int productId)
        {
            var basket = GetBasketFromCookie();
            var basektItem = basket.FirstOrDefault(item=>item.ProductId == productId);

            if (basektItem != null)
                basektItem.Quantity++;
            else
            {
                basket.Add(new BasketCookieItemViewModel
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
            var basketItem = basket.FirstOrDefault(item=>item.ProductId==productId);
        }

        public async Task<BasketViewModel> GetBasketAsync()
        {
            var basket = GetBasketFromCookie();
            var basketViewModel = new BasketViewModel();

            foreach(var item in basket)
            {
                var product = await _productService.GetByIdAsync(item.ProductId);

                if(product!= null)
                {
                    basketViewModel.Items.Add(new BasketItemViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name!,
                        ImageName = product.CoverImageName!,
                        Price = product.Price,
                        Quantity = item.Quantity,
                    });
                }
            }

            return basketViewModel;
        }

        public async Task<BasketViewModel> ChangeQuantityAsync(int productId, int quantity)
        {
            var basket = GetBasketFromCookie();
            var basketItem = basket.FirstOrDefault(item => item.ProductId == productId);

            if (basketItem != null)
            {
                basketItem.Quantity += quantity;

                SaveBasketToCookie(basket);
            }

            var basketViewModel = new BasketViewModel();

            foreach (var item in basket)
            {
                var product = await _productService.GetByIdAsync(item.ProductId);

                if (product != null)
                {
                    basketViewModel.Items.Add(new BasketItemViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name!,
                        ImageName = product.CoverImageName!,
                        Price = product.Price,
                        Quantity = item.Quantity,
                    });
                }
            }

            return basketViewModel;

        }

        private List<BasketCookieItemViewModel> GetBasketFromCookie()
        {
            var cookie = _httpContextAccessor.HttpContext?.Request.Cookies[BasketCookieName];

            if (string.IsNullOrEmpty(cookie))
            {
                return new List<BasketCookieItemViewModel>();
            }

            return JsonSerializer.Deserialize<List<BasketCookieItemViewModel>>(cookie) ?? [];
        }

        private void SaveBasketToCookie(List<BasketCookieItemViewModel> basket)
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
