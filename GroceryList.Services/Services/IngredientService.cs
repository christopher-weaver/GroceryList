using GroceryList.Data;
using GroceryList.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;

        public IngredientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            var newIngredient =
                new Ingredient()
                {
                    UserId = _userId,
                    Name = model.Name,
                    Grams = model.Grams,
                    Cost = model.Cost,
                    //DateOfPurchase = model.DateOfPurchase,
                    //ExpirationDate = model.ExpirationDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(newIngredient);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IngredientDisplay> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ingredients
                               .Select(d => new IngredientDisplay
                               {
                                   Id = d.Id,
                                   Name = d.Name,
                                   Grams = d.Grams,
                                   Cost = d.Cost,
                                   // DateOfPurchase = d.DateOfPurchase,
                                   // ExpirationDate = d.ExpirationDate
                               });

                return query.ToArray();
            }
        }

        public bool UpdateIngredient(IngredientEdit editedIngredient)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ingredientToEdit =
                    ctx
                        .Ingredients
                        .Single(d => d.Id == editedIngredient.Id && d.UserId == _userId);

                ingredientToEdit.Name = editedIngredient.Name;
                ingredientToEdit.Grams = editedIngredient.Grams;
                ingredientToEdit.Cost = editedIngredient.Cost;
                // ingredientToEdit.DateOfPurchase = editedIngredient.DateOfPurchase;
                // ingredientToEdit.ExpirationDate = editedIngredient.ExpirationDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var ingredientToDelete =
                    ctx
                        .Ingredients
                        .Single(d => d.Id == ingredientId && d.UserId == _userId);

                ctx.Ingredients.Remove(ingredientToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
