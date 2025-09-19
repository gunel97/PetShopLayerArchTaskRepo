﻿using Microsoft.AspNetCore.Http;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.Services
{
    public class WishlistManager
    {
        private const string WishlistCookieName = "wishlist";

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductService _productService;

        public WishlistManager(IHttpContextAccessor httpContextAccessor, IProductService productService)
        {
            _httpContextAccessor = httpContextAccessor;
            _productService = productService;
        }

        public void AddToWishlist(int productId)
        {
            var wishlist = GetWishlistFromCookie();

            var wishlistItem = wishlist.FirstOrDefault(item => item.ProductId == productId);
            if (wishlistItem == null)
            {
                wishlist.Add(new WishlistCookieItemViewModel
                {
                    ProductId = productId,
                });
            }

            SaveWishlistToCookie(wishlist);
        }

        public void RemoveFromWishlist(int productId)
        {
            var wishlist = GetWishlistFromCookie();
            var wishlistItem = wishlist.FirstOrDefault(item => item.ProductId == productId);
            if (wishlistItem != null)
            {
                wishlist.Remove(wishlistItem);
                SaveWishlistToCookie(wishlist);
            }
        }

        public async Task<List<WishlistItemViewModel>> GetWishlistAsync()
        {
            var wishlist = GetWishlistFromCookie();
            var wishlistViewModel = new List<WishlistItemViewModel>();
            foreach (var item in wishlist)
            {
                var product = await _productService.GetByIdAsync(item.ProductId);
                if (product != null)
                {
                    wishlistViewModel.Add(new WishlistItemViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name!,
                        ImageName = product.CoverImageName!,
                        Price = product.Price,
                    });
                }
            }
            return wishlistViewModel;
        }

        private List<WishlistCookieItemViewModel> GetWishlistFromCookie()
        {
            var cookie = _httpContextAccessor.HttpContext?.Request.Cookies[WishlistCookieName];
            if (string.IsNullOrEmpty(cookie))
            {
                return new List<WishlistCookieItemViewModel>();
            }
            return System.Text.Json.JsonSerializer.Deserialize<List<WishlistCookieItemViewModel>>(cookie) ?? [];
        }

        private void SaveWishlistToCookie(List<WishlistCookieItemViewModel> wishlist)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,
            };
            var cookieValue = System.Text.Json.JsonSerializer.Serialize(wishlist);
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(WishlistCookieName, cookieValue, cookieOptions);
        }

    }
}
