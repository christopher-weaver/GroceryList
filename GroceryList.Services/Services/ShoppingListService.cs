using GroceryList.Data;
using GroceryList.Data.DataModels;
using GroceryList.Models;
using GroceryList.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public class ShoppingListService
    {
        private readonly Guid _userId;
        public ShoppingListService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShoppingList(ShoppingListCreate shoppingList)
        {
            var entity = new ShoppingList
            {
                UserId = _userId,
                StoreName = shoppingList.StoreName,
                Ingredients = shoppingList.Ingredients,
                DateOfTrip = shoppingList.DateOfTrip,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingLists.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<ShoppingListItem> GetShoppingList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ShoppingLists
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new ShoppingListItem
                        {
                            Id = e.Id,
                            DateOfTrip = e.DateOfTrip,
                            StoreName = e.StoreName,
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

        public bool UpdateShoppingList(ShoppingListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ShoppingLists
                    .Single(e => e.Id == model.Id && e.UserId == _userId);

                entity.Id = model.Id;
                entity.StoreName = model.StoreName;
                entity.DateOfTrip = model.DateOfTrip;

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

        public bool DeleteShoppingList(int shoppingListId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var shoppingListQry =
                    ctx
                    .ShoppingLists
                    .Single(s => s.Id == shoppingListId && s.UserId == _userId);

                for (var i = 0; i < shoppingListQry.Ingredients.Count; i++)
                {
                    var ingredientId = shoppingListQry.Ingredients[i].Id;

                    var ingredientToDelete =
                    ctx
                        .Ingredients
                        .Single(d => d.Id == ingredientId && d.UserId == _userId);

                    ctx.Ingredients.Remove(ingredientToDelete);
                }

                ctx.ShoppingLists.Remove(shoppingListQry);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
