﻿using CakeShop.Core.Models;
using CakeShop.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICakeRepository _cakeRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(ICakeRepository cakeRepository, IShoppingCart shoppingCart)
        {
            _cakeRepository = cakeRepository;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Index()
        {
            await _shoppingCart.GetShoppingCartItemsAsync();
            var shoppingCartCountTotal = await _shoppingCart.GetCartCountAndTotalAmmountAsync();
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartItemsTotal = shoppingCartCountTotal.ItemCount,
                ShoppingCartTotal = shoppingCartCountTotal.TotalAmmount,
            };


            return View(shoppingCartViewModel);
        }

        public async Task<IActionResult> AddToShoppingCart(int cakeId)
        {
            var selectedCake = await _cakeRepository.GetCakeById(cakeId);
            if (selectedCake == null)
            {
                return NotFound();
            }

            await _shoppingCart.AddToCartAsync(selectedCake);

            return RedirectToAction("Index");
        }
    }
}