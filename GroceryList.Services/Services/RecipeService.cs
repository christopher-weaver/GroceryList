using GroceryList.Data;
using GroceryList.Data.DataModels;
using GroceryList.Models;
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
                return ctx.SaveChanges() == 1;
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
                                    RecipeName = e.RecipeName
                                }
                            );
                return query.ToArray();
            }
        }

    }
}
