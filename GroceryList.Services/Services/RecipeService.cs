using GroceryList.Data;
using GroceryList.Data.DataModels;
using GroceryList.Models;
using GroceryList.Models.Models;
using GroceryList.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;
        public RecipeService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                    new Recipe()
                    {
                        UserId = _userId,
                        RecipeName = model.RecipeName,
                        Ingredients = model.Ingredients
                    };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                        ctx
                        .Recipes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    Id = e.Id,
                                    RecipeName = e.RecipeName,
                                    Ingredients = e.Ingredients
                                           .Select(i =>
                                                     new IngredientDisplay
                                                     {
                                                         Name = i.Name,
                                                         Grams = i.Grams,
                                                         Cost = i.Cost
                                                     }).ToList()
                                }
                            );
                return query.ToArray();
            }
        }


        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recipes
                    .Single(e => e.Id == model.Id && e.UserId == _userId);

                entity.Id = model.Id;
                entity.RecipeName = model.RecipeName;

                for (var i = 0; i < entity.Ingredients.Count; i++)
                {
                    var ingredientId = entity.Ingredients[i].Id;

                    var ingredientToDelete =
                    ctx
                        .Ingredients
                        .Single(d => d.Id == ingredientId && d.UserId == _userId);

                    ctx.Ingredients.Remove(ingredientToDelete);
                }

                entity.Ingredients = model.Ingredients;

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var recipeQry =
                    ctx
                    .Recipes
                    .Single(r => r.Id == recipeId && r.UserId == _userId);

                for (var i = 0; i < recipeQry.Ingredients.Count; i++)
                {
                    var ingredientId = recipeQry.Ingredients[i].Id;

                    var ingredientToDelete =
                    ctx
                        .Ingredients
                        .Single(d => d.Id == ingredientId && d.UserId == _userId);

                    ctx.Ingredients.Remove(ingredientToDelete);
                }

                ctx.Recipes.Remove(recipeQry);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
