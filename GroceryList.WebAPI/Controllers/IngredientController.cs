using GroceryList.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryList.WebAPI.Controllers
{
    public class IngredientController : ApiController
    {
        // POST - Create an Ingredient
        [HttpPost]
        public IHttpActionResult Post(IngredientCreate ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingredientService = CreateIngredientService();

            if (!ingredientService.CreateIngredient(ingredient))
            {
                return InternalServerError();
            }

            return Ok($"The following ingredient has been added: {ingredient.Name}");
        }

        // GET - All Ingredients
        [HttpGet]
        public IHttpActionResult Get()
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredients = ingredientService.GetIngredients();
            return Ok(ingredients);
        }

        // PUT - Update an Ingredient
        [HttpPut]
        public IHttpActionResult Put(IngredientEdit ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateIngredientService();

            if (!service.UpdateIngredient(ingredient))
            {
                return InternalServerError();
            }

            return Ok();
        }

        // DELETE - Remove an Ingredient
        [HttpDelete]
        [Route("api/Ingredient/{ingredientId}")]
        public IHttpActionResult Delete([FromUri] int ingredientId)
        {
            var service = CreateIngredientService();

            if (!service.DeleteIngredient(ingredientId))
            {
                return InternalServerError();
            }

            return Ok();
        }


        // Helper Methods
        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ingredientService = new IngredientService(userId);
            return ingredientService;
        }
    }
}
