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
   public class ShoppingListService
    {
        private readonly Guid _userId;
        public ShoppingListService(Guid userId)
        {
            _userId = userId;
        }

        public bool Post(ShoppingListCreate shoppingList)
        {
            var entity = new ShoppingList
            {
                StoreName = shoppingList.StoreName,
                Ingredients = shoppingList.Ingredients,
                DateOfTrip = shoppingList.DateOfTrip
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShoppingListItem> GetShoppingList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                    .ShoppingLists
                    
            }
        }

        public bool EditComment(ShoppingListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ShoppingLists
                    
            }
        }
    }
}
