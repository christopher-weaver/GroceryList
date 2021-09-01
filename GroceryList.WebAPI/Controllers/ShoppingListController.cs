using GroceryList.Models;
using GroceryList.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace GroceryList.WebAPI.Controllers
{
    public class ShoppingListController : ApiController
    {
        private ShoppingListService CreateShoppingListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var shoppingListService = new ShoppingListService(userId);
            return shoppingListService;
        }
        public IHttpActionResult Get()
        {
            ShoppingListService shoppingListService = CreateShoppingListService();
            var ingredients = shoppingListService.GetShoppingList();
            return Ok(ingredients);
        }

        public IHttpActionResult Post(ShoppingListCreate shoppingList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); ;

            var service = CreateShoppingListService();

            if (!service.CreateShoppingList(shoppingList))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ShoppingListEdit shoppingList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShoppingListService();

            if (!service.UpdateShoppingList(shoppingList))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateShoppingListService();
            if (!service.DeleteShoppingList(id))
                return InternalServerError();

            return Ok();
        }
    }
}
