﻿using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMoviesService _movieService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _orderService;
        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService orderService)
        {
            _movieService = moviesService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return View(orders);
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
            var item = await _movieService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAdress = "";

            await _orderService.StoreOrderAsync(items, userId, userEmailAdress);
            await _shoppingCart.ClearShoppingCartAsync();
            
            return View("OrderCompleted");
        }
    }
}