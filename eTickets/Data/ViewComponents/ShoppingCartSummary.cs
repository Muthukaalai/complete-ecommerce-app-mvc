using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewComponents
{
    // [ViewComponent] - second way to use as view component
    // Inherit from base class ViewComponent - third way to use as view component (    public class ShoppingCartSummary:ViewComponent)
    // while creating cs file add naming with ViewComponent it consider as VC - first way
    // refer layout.cshtml to configure VC
   // [ViewComponent]
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
